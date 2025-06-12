package blogzp.main;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import blogzp.main.dao.BlogDAO;
import blogzp.main.dao.CategoryDAO;
import blogzp.main.dao.CommentDAO;
import blogzp.main.dao.MessagesDAO;
import blogzp.main.dao.SlideItemDAO;
import blogzp.main.dao.TagDAO;
import blogzp.main.dao.UserDAO;
import blogzp.main.entity.Blog;
import blogzp.main.entity.Comment;
import blogzp.main.entity.Keyword;
import blogzp.main.entity.Messages;
import blogzp.main.entity.SlideItem;
import blogzp.main.entity.User;

@Controller
@RequestMapping("/")
public class FrontControler {
	
	@Autowired
	private SlideItemDAO slideitemDAO;
	@Autowired
	private BlogDAO blogDAO;
	@Autowired
	private CategoryDAO categoryDAO;
	@Autowired
	private TagDAO tagDAO;
	@Autowired
	private CommentDAO commentDAO;
	@Autowired
	private UserDAO userDAO;
	@Autowired
	private MessagesDAO messagesDAO;
	
	@RequestMapping({"/", "/index-page"})
	public String getIndexPage(Model model) {
		model.addAttribute("slideitems",slideitemDAO.getSlideItemEnabled()); //salje slajdove koje se prikazuju
		model.addAttribute("blogs",blogDAO.getBlogsIsOnPageImpTop4()); //salje blogove koji su cekirani da se prikazuju
		
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		
		//priprema 4 puta po 3 bloga za prikaz na slajdu
		List<Blog> list12 = blogDAO.getBlogsIsOnPageTop12();
		List<Blog> listA = new ArrayList<Blog>();
		List<Blog> listB = new ArrayList<Blog>();
		List<Blog> listC = new ArrayList<Blog>();
		List<Blog> listD = new ArrayList<Blog>();

		for(int i = 0; i < 12; i++) {
			if (i < 3) {
				listA.add(list12.get(i));
			} else if (i < 6) {
				listB.add(list12.get(i));
			} else if (i < 9) {
				listC.add(list12.get(i));
			} else if (i < 12) {
				listD.add(list12.get(i));
			}
		}
		model.addAttribute("blogsA", listA);
		model.addAttribute("blogsB", listB);
		model.addAttribute("blogsC", listC);
		model.addAttribute("blogsD", listD);
		
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		//salje zadnje 3 (not important)
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3());
		
		return "front/index-page";
	}
	
	// prikaz svih postova (blogova)
	@RequestMapping("/blog-page")
	public String getBlogPage(Model model) {
		//salje blogove koji su cekirani da se prikazuju
		model.addAttribute("blogs",blogDAO.getBlogsIsOnPage());
		
		// ovo je ISTO za sve varijante - moze se smestiti u metodu (smanjiti kod)
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		
		//salje zadnja 3 (important sa najvise pregleda)
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3());	
		// sve kategorije sa brojem povezanih postova - aside
		model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
		// svi tagovi - aside
		model.addAttribute("tagList", tagDAO.getTagListWithBlogs());
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta dole desno
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)
		
		return "front/blog-page";
	}
	
	@RequestMapping("/blog-page-filter")
	public String getProductPageFilter(@RequestParam int id,@RequestParam String type, Model model) { // filtrira po prosledjenom id-ju kategorije
		
		if (type.equalsIgnoreCase("category")) {
		
			// prosledjujemo filtrirane proizvode PO KATEGORIJI
			List<Blog> blogsOnPage = blogDAO.getBlogListByCategory(id);
			// upisuje u polje objekta formatirano vreme kreiranja i broj komentara
			DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMMM yyyy");	    
			for(Blog b : blogsOnPage) {
				b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
				b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
			}
			model.addAttribute("blogs", blogsOnPage);

		}
		else if (type.equalsIgnoreCase("tag")) {
			
			// prosledjujemo filtrirane proizvode PO TAGU
			// treba da brise blogove koji nisu cekirani za prikaz
			List<Blog> blogsOnPage = blogDAO.getBlogListByTag(id);
			// upisuje u polje objekta formatirano vreme kreiranja i broj komentara
			DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMMM yyyy");	    
			for(Blog b : blogsOnPage) {
				b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
				b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
			}
			model.addAttribute("blogs", blogsOnPage);
		}
		
		// ovo je ISTO za sve varijante
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		//salje zadnja 3 (important sasa najvise pregleda)
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3());	
		// sve kategorije sa brojem povezanih postova - aside
		model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
		// svi tagovi - aside
		model.addAttribute("tagList", tagDAO.getTagListWithBlogs());
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta dole desno
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)
		
		return "front/blog-page";
	}
	
	@RequestMapping("post-search")
	public String getPostSearch(@ModelAttribute Keyword keyword, Model model) {		
		
		// salje postove koji su prosli pretragu
		model.addAttribute("blogs",blogDAO.getPostSearch(keyword.getKeyword())); //salje kljucnu rec za pretragu		


		// ovo je ISTO za sve varijante
		// salje prazan string - keyword
		model.addAttribute("keyword", new Keyword());
		//salje zadnja 3 (important sasa najvise pregleda)
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3());	
		// sve kategorije sa brojem povezanih postova - aside
		model.addAttribute("categoryList",categoryDAO.getCategoriesForFilter());
		// svi tagovi - aside
		model.addAttribute("tagList", tagDAO.getTagListWithBlogs());
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta dole desno
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)
		
		return "front/blog-page";
	}
	
	// prikaz pojedinacnog posta
	@RequestMapping("blog-item-page")
	public String getBlogItemPage(@RequestParam int id, Model model) {
		
		// ubacije objekat za izabran blog u varijablu
		Blog chosen_blog = blogDAO.getBlogWithTag(id);
		// ubacuje u polje commentNumb broj komentara za ovaj post (blog)
		chosen_blog.setCommentNumb(commentDAO.getCommentsPostList(id).size());
		// vraca na isti post
		model.addAttribute("post", chosen_blog);
		
		// salje vec upisane komentare za taj post
		model.addAttribute("commentsPost", commentDAO.getCommentsPostList(id));
		// salje prazan objekat u formu da pokupi podatke (popunjena polja)
		Comment comment = new Comment();
		model.addAttribute("comment",comment);
		
		//BROJAC pregleda posta (uzima trenutni broj i dodaje jedan)
		Blog blog = blogDAO.getBlog(id);
		blog.setReviewNumb(blog.getReviewNumb() + 1);
		blogDAO.saveBlog(blog);
		
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		// aside postavke
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3()); //salje zadnja 3 (important sasa najvise pregleda)
		model.addAttribute("categoryList", categoryDAO.getCategoriesForFilter());
		model.addAttribute("tagList", tagDAO.getTagListWithBlogs());
		// 4 kategorije sa najvise blogova - footer
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta u footeru - footer
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)
		
		return "front/blog-post";
	}
	
	// poziva sa dugmeta submit "Save comment" iz blog-post.jsp
	@RequestMapping("/comment-front-save") // cuva (sejvuje) tag objekat prosledjen iz jsp stranice comment-form
	public String saveFrontComment(@RequestParam int postId, @ModelAttribute Comment comment, Model model) { 
		
		// postavlja objekat blog u polje objekta comment prema id-ju poslednjeg posta
		comment.setBlog(blogDAO.getBlog(postId));
		// uzima blog prema prosledjenom id-ju da bi ga ponovo prikazao
		Blog chosen_blog = blogDAO.getBlogWithTag(postId);
		model.addAttribute("post", chosen_blog);
		
		// postavlja automatski da se komentar vidi dok se ne ukloni
		comment.setEnabled(true);
		// unosi trenutno vreme kreiranja komentara
		comment.setCommDate(LocalDateTime.now());
		// unosi u bazu prosledjeni komentar
		commentDAO.saveComment(comment); // u commentDAOImpl. cuva komentar
		// uzima listu svih komentara
		model.addAttribute("commentsPost", commentDAO.getCommentsPostList(postId));
		
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		// aside postavke
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3()); //salje zadnja 3 (important sasa najvise pregleda)
		model.addAttribute("categoryList", categoryDAO.getCategoriesForFilter());
		model.addAttribute("tagList", tagDAO.getTagListWithBlogs());		
		// salje prazan objekat u formu da pokupi podatke (popunjena polja)
		Comment commentNew = new Comment();
		model.addAttribute("comment",commentNew);
		// 4 kategorije sa najvise blogova - footer
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta u footeru - footer
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)
		
		return "front/blog-post";

	}	
	
	@RequestMapping("/contact-page")
	public String getContactPage(Model model) {
		Messages message = new Messages();
		model.addAttribute("message",message);
		
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3()); //salje zadnja 3 (important posta sa najvise pregleda)
		
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta u footeru - footer
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)
		
		return "front/contact-page";
	}
	
	@RequestMapping("/message-front-save")
	public String getMessageSave(Model model, Messages message) {
		messagesDAO.saveMessage(message); // zavisno od id-ja, u messagesDAOImpl. cuva ili menja name
		message = new Messages();
		model.addAttribute("message",message);
		
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnja 3 (important sasa najvise pregleda)
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3()); //salje zadnje 3 (important)
		
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());

		return "front/contact-page";
	}
	
	// prikaz svih postova (blogova) jednog autora
	// @RequestParam mora biti ISTOG IMENA kao sto poslat sa jsp stranice
	@RequestMapping("/author-page")
	public String getAuthorPage(Model model, @RequestParam String username) {		

		// prosledjujemo podatke o AUTORU
		model.addAttribute("author", userDAO.getUserByUsername(username));
		
		// prosledjujemo filtrirane postove PO AUTORU
		model.addAttribute("authorBlogs", blogDAO.getBlogListByAuthor(username));
		//System.out.println(blogDAO.getBlogListByAuthor(username));
		
		// salje prazan string keyword
		model.addAttribute("keyword", new Keyword());
		// aside - popunjava blogove, kategorije i tagove
		model.addAttribute("blogsImp3",blogDAO.getBlogsIsOnPageImpTop3()); //salje zadnja 3 (important sasa najvise pregleda)
		model.addAttribute("categoryList", categoryDAO.getCategoriesForFilter());
		model.addAttribute("tagList", tagDAO.getTagListWithBlogs());
		
		// 4 kategorije sa najvise blogova
		model.addAttribute("cat4blogs", categoryDAO.get4CategoriesMoreBlogs());
		// 3 posta u footeru
		model.addAttribute("blogs3",blogDAO.getBlogsIsOnPageTop3()); //salje zadnje 3 (not important)

		
		return "front/author-page";
	}
	
}
