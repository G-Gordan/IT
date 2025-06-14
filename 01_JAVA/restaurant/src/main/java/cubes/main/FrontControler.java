package cubes.main;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import cubes.main.dao.CategoryDAO;
import cubes.main.dao.EmployeeDAO;
import cubes.main.dao.ProductDAO;
import cubes.main.dao.ReservationDAO;
import cubes.main.dao.TagDAO;
import cubes.main.entity.Product;
import cubes.main.entity.Reservation;

@Controller
@RequestMapping("/")
public class FrontControler {
	
	@Autowired
	private CategoryDAO categoryDAO;	
	@Autowired
	private ReservationDAO reservationDAO;
	@Autowired
	private ProductDAO productDAO;
	@Autowired
	private TagDAO tagDAO;
	@Autowired
	private EmployeeDAO employeeDAO;
	
	@RequestMapping({"/", "/index-page"})
	public String getIndexPage(Model model) {
		model.addAttribute("categories",categoryDAO.getCategoriesOnMainPage());
		model.addAttribute("reservation", new Reservation());
		return "front/index-page";
	}
	
	@RequestMapping("/reservation-save")
	public String saveReservation(@Valid @ModelAttribute Reservation reservation, BindingResult result, Model model) {
		if(result.hasErrors()) {
			model.addAttribute("categories", categoryDAO.getCategoriesOnMainPage());
			return "front/index-page";
		}		
		reservationDAO.saveReservation(reservation);
		return "redirect: index-page";
	}
	
	@RequestMapping("/about-page")
	public String getAboutPage(Model model) {
		model.addAttribute("employeeList", employeeDAO.getEmployeeList());
		return "front/about-page";
	}
	
	@RequestMapping("/menu-page")
	public String getMenuPage(Model model) {
		model.addAttribute("categoryList", categoryDAO.getCategoriesOnMenuPage());		
		return "front/menu-page";
	}
	
	@RequestMapping("/products-page")
	public String getProductsPage(Model model) {		
		List<Product> productList = productDAO.getProductList();
		model.addAttribute("productList", productList);
		model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
		model.addAttribute("tagList", tagDAO.getTagListWithProducts());
		return "front/products-page";
	}
	
	@RequestMapping("/products-page-filter")
	public String getProductPageFilter(@RequestParam int id,@RequestParam String type, Model model) { // filtrira po prosledjenom id-ju kategorije
		if (type.equalsIgnoreCase("category")) {
			model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
			model.addAttribute("tagList", tagDAO.getTagListWithProducts());			
			model.addAttribute("productList", productDAO.getProductListByCategory(id));			
		}
		else if (type.equalsIgnoreCase("tag")) {
			model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
			model.addAttribute("tagList", tagDAO.getTagListWithProducts());			
			model.addAttribute("productList", productDAO.getProductListByTag(id));			
		}		
		return "front/products-page";
	}
	
	@RequestMapping("/products-page-order")
	public String getProductListOrderPage(@RequestParam int orderBy, Model model) { //@RequestParam prihvata parametre sa jsp stranice
		model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
		model.addAttribute("tagList", tagDAO.getTagListWithProducts());			
		model.addAttribute("productList", productDAO.getProductList(orderBy));		
		return "front/products-page";
	}
	
	@RequestMapping("/product-item-page")
	public String getProductItem(@RequestParam int id, Model model) {

		Product izabran_proizvod = productDAO.getProductWithTag(id);

		model.addAttribute("product", izabran_proizvod);

		model.addAttribute("related", productDAO.getProductListByCategory(izabran_proizvod.getCategory().getId()));
		
		return "front/product-item-page";

	}

}
