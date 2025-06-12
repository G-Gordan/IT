package blogzp.main;

import java.security.Principal;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import blogzp.main.entity.Blog;
import blogzp.main.entity.Category;
import blogzp.main.entity.Comment;
import blogzp.main.entity.Messages;
import blogzp.main.entity.Role;
import blogzp.main.entity.Tag;
import blogzp.main.entity.ChangePassword;
import blogzp.main.entity.User;
import blogzp.main.entity.SlideItem;
import blogzp.main.dao.BlogDAO;
import blogzp.main.dao.CategoryDAO;
import blogzp.main.dao.CommentDAO;
import blogzp.main.dao.MessagesDAO;
import blogzp.main.dao.TagDAO;
import blogzp.main.dao.UserDAO;
import blogzp.main.dao.SlideItemDAO;

@Controller
@RequestMapping("/admin")
public class AdminControler {
	
	@Autowired
	private BlogDAO blogDAO;
	@Autowired
	private CategoryDAO categoryDAO;
	@Autowired
	private TagDAO tagDAO;
	@Autowired
	private SlideItemDAO slideitemDAO;
	@Autowired
	private CommentDAO commentDAO;
	@Autowired
	private MessagesDAO messagesDAO;
	@Autowired
	private UserDAO userDAO;
	

	
	@RequestMapping("/blog-form")
	public String getBlogForm(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Blog blog = new Blog();		
		model.addAttribute("blog",blog);
				
		List<Category> categoryList = categoryDAO.getCategoryList();// pravi listu i salje na stranicu za padajucu listu
		model.addAttribute("categoryList",categoryList); // prvo categoryList se salje u formu product-form.jsp
		
		List<Tag> tagList = tagDAO.getTagList();
		model.addAttribute("tagList", tagList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());
		
		//da se element za upozorenje ne aktivira bez potrebe...
		Boolean isUserBloger = true;
		model.addAttribute("isUserBloger", isUserBloger);
		
		return "blog-form";
	}
	
	@RequestMapping("/blog-save")
	public String saveBlog(Principal principal, Model model, @Valid @ModelAttribute Blog blog, BindingResult result) {

		// ako je pogresan upis, vraca ponovo formu za unos...
		if (result.hasErrors()) {
			return "blog-form";
		}
		
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		// da ne bi prebrisao name u tabeli category, posto se salje samo jedan id...
		Category category = categoryDAO.getCategory(blog.getCategory().getId());
		blog.setCategory(category); // ceo slog category, a ne samo "id" bez "name" se sada ubacuje u blog

		// u listu ids ubacije izabrane tagove
		List<Integer> ids = new ArrayList<Integer>();
		for(Tag tag: blog.getTags()) { //posle submit, iz objekta blog (iz blog-form) uzima sve selektovane tagove
			// ZASTO tag.getName a ne tag.getId ?
			// id je upisan kao string u polje name objekta tag -> u klasi tag U PARAMETARSKOM KONSTRUKTORU NEMA POLJA ZA id !
			ids.add(Integer.parseInt(tag.getName())); //  i njihove id-jeve konvertuje iz string u integer
		}
		//pravi listu tagova prema prosledjenim idjevima
		List<Tag> tags = tagDAO.getTagsById(ids);		
		blog.setTags(tags); // cele slogove izabranih tagova ubacuje u objekat blog
		
		// unosi trenutno vreme kreiranja bloga
		blog.setBlogCreated(LocalDateTime.now());
		// broj neprocitanih message-a
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());
		
		// povezuje trenutno ulogovanog blogera sa ovim blogom
		blog.setAuthor(user);

		// proverava da li user ima bloger rolu i ako nema vraca na form sa upozorenjem...
		List<Role> listaRole = user.getAuthorities();
		Boolean isUserBloger = false;
		for(Role r : listaRole) {
			if(r.getAuthority().equals("ROLE_bloger")) {
				blogDAO.saveBlog(blog);
				isUserBloger = true;				
			} 
		}
		// mora da vrati sa inicijatorom za upozorenje na blog-form.jsp !!!
		if(!isUserBloger) {
			model.addAttribute("isUserBloger", isUserBloger);
						return "blog-form";
		}
		
		return "redirect:/admin/blog-list";
	}

	@RequestMapping("/blog-list")
	public String getBlogList(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<Blog> list = blogDAO.getBlogList();		
		model.addAttribute("blogList",list);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "blog-list";
	}
	
	@RequestMapping("/blog-form-update")
	public String getBlogUpdateForm(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		// polje tags u klasi Blog nije iz tabele blog, kao sto je idCategory iz tabele blog (polje category klase Blog)
		// objekat blog ne povlaci automatski vezane tagove kao sto povlaci vezane kategorije koj imaju polje u tabeli baze
		// zato se objekat blog posebno puni tagovima preko getTags() objekta blog i iniciranjem LAZY
		Blog blog = blogDAO.getBlogWithTag(id);	//new Blog(); ovo je bilo prethodno pa je promenjeno zbog LAZY (za ManyToMany)	
		model.addAttribute("blog",blog);
		
		List<Category> categoryList = categoryDAO.getCategoryList();// pravi listu i salje na stranicu za padajucu listu
		model.addAttribute("categoryList",categoryList); // prvo categoryList se salje u formu, derugo je objekat ove metode

		List<Tag> tagList = tagDAO.getTagList();
		model.addAttribute("tagList", tagList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());
		
		// da se element za upozorenje ne aktivira bez potrebe...
		Boolean isUserBloger = true;
		model.addAttribute("isUserBloger", isUserBloger);

		return "blog-form";
	}
	
	@RequestMapping("/blog-delete")
	public String deleteBlog(Principal principal, Model model, @RequestParam int id) {	
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		blogDAO.deleteBlog(id);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "redirect:/admin/blog-list";
	}
	
	@RequestMapping("/blog-sort")
	public String getBlogSort(Principal principal, @RequestParam int orderBy, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);

		List<Blog> list = blogDAO.getBlogByOrder(orderBy);		

		model.addAttribute("blogList",list);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "blog-list";
	}
	
	
	/* CATEGORY */
	@RequestMapping("/category-form")
	public String getCategoryForm(Principal principal,Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Category category = new Category();		
		model.addAttribute("category",category);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "category-form";
	}
	
	@RequestMapping("/category-save")
	public String saveCategory(Principal principal, Model model, @ModelAttribute Category category) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);

		categoryDAO.saveCategory(category);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "redirect:/admin/category-list";
	}

	@RequestMapping("/category-list")
	public String getCategoryList(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<Category> list = categoryDAO.getCategoryList();		
		model.addAttribute("categoryList",list);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "category-list";
	}
	
	@RequestMapping("/category-form-update")
	public String getCategoryUpdateForm(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Category category = categoryDAO.getCategory(id);	//new Category(); ovo je bilo prethodno pa je promenjeno	
		model.addAttribute("category",category);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "category-form";
	}
	
	@RequestMapping("/category-delete")
	public String deleteCategory(Principal principal, Model model, @RequestParam int id) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		categoryDAO.deleteCategory(id);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "redirect:/admin/category-list";
	}
	
	
	/* TAG */
	@RequestMapping("/tag-form")
	public String getTagForm(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Tag tag = new Tag();
		model.addAttribute("tag",tag);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "tag-form";
	}
	
	// poziva sa dugmeta submit "Save tag" iz tag-form.jsp
	@RequestMapping("/tag-save") // cuva (sejvuje) tag objekat prosledjen iz jsp stranice tag-form
	public String saveTag(Principal principal, Model model, @ModelAttribute Tag tag) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
	
		tagDAO.saveTag(tag); // zavisno od id-ja, u tagDAOImpl. cuva ili menja name
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "redirect:/admin/tag-list"; // redirekcija dopunjuje putanju od root-a
	}

	@RequestMapping("/tag-list")
	public String getTagList(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<Tag> tagList = tagDAO.getTagList();
		model.addAttribute("tagList", tagList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "tag-list";
	}
	
	// poziva se sa dugmeta Update iz tag-form.jsp
	@RequestMapping("/tag-form-update")
	public String getTagUpdateForm(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Tag tag = tagDAO.getTag(id);	// uzima objekat pod zadatim id-jem
		model.addAttribute("tag",tag); // kad otvorimo formu, preko kez-a ispisuje ime taga koji treba da se menja
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "tag-form";
	}	
	
	// poziva se sa dugmeta Delete iz tag-form.jsp
	@RequestMapping("/tag-delete")
	public String deleteTag(Principal principal, Model model, @RequestParam int id) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		tagDAO.deleteTag(id);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		

		return "redirect:/admin/tag-list";
	}
	

	/* SLIDE ITEM */
	@RequestMapping("/slideitem-form")
	public String getSlideItemForm(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		SlideItem slideitem = new SlideItem();
		model.addAttribute("slideitem",slideitem);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "slideitem-form";
	}
	
	// poziva sa dugmeta submit "Save slideitem" iz slideitem-form.jsp
	@RequestMapping("/slideitem-save") // cuva (sejvuje) slideitem objekat prosledjen iz jsp stranice slideitem-form
	public String saveSlideItem(Principal principal, @ModelAttribute SlideItem slideitem, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
	
		slideitemDAO.saveSlideItem(slideitem); // zavisno od id-ja, u slideitemDAOImpl. cuva ili menja name
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		//return "slideitem-form";
		return "redirect:/admin/slideitem-list"; // redirekcija dopunjuje putanju od root-a
	}

	@RequestMapping("/slideitem-list")
	public String getSlideItemList(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<SlideItem> slideitemList = slideitemDAO.getSlideItemList();
		model.addAttribute("slideitemList", slideitemList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "slideitem-list";
	}
	
	// poziva se sa dugmeta Update iz slideitem-form.jsp
	@RequestMapping("/slideitem-form-update")
	public String getSlideItemUpdateForm(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		SlideItem slideitem = slideitemDAO.getSlideItem(id);	// uzima objekat pod zadatim id-jem
		model.addAttribute("slideitem",slideitem); // kad otvorimo formu, preko kez-a ispisuje ime slideitema koji treba da se menja
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "slideitem-form";
	}	
	
	// poziva se sa dugmeta Delete iz slideitem-form.jsp
	@RequestMapping("/slideitem-delete")
	public String deleteSlideItem(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		slideitemDAO.deleteSlideItem(id);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/slideitem-list";
	}
	
	
	/* COMMENT */
	@RequestMapping("/comment-list")
	public String getCommentsList(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<Comment> commentsList = commentDAO.getCommentsList();
		model.addAttribute("commentList", commentsList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "comment-list";
	}
	
	// # tokom izrade projekta postojala je stranica "comment-form.jsp #
	@RequestMapping("/comment-form")
	public String getCommentForm(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Comment comment = new Comment();
		model.addAttribute("comment",comment);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "comment-form";
	}
	
	// # tokom izrade projekta postojala je stranica "comment-form.jsp #
	// poziva sa dugmeta submit "Save comment" iz comment-form.jsp
	@RequestMapping("/comment-save") // cuva (sejvuje) tag objekat prosledjen iz jsp stranice comment-form
	public String saveComment(Principal principal, /*@Valid*/ @ModelAttribute Comment comment/*, BindingResult result*/, Model model) { 
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);

		// unosi trenutno vreme kreiranja komentara
		comment.setCommDate(LocalDateTime.now());		
		commentDAO.saveComment(comment); // zavisno od id-ja, u commentDAOImpl. cuva ili menja name
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());
		
		return "redirect:/admin/comment-list"; // redirekcija dopunjuje putanju od root-a
	}
	
	// # tokom izrade projekta postojala je stranica "comment-form.jsp #
	// poziva se sa dugmeta Update iz comment-form.jsp
	@RequestMapping("/comment-form-update")
	public String getCommentUpdateForm(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Comment comment = commentDAO.getComment(id);	// uzima objekat pod zadatim id-jem
		model.addAttribute("comment",comment); // kad otvorimo formu, preko kez-a ispisuje ime comment-a koji treba da se menja
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "comment-form";
	}	
	
	// poziva se sa dugmeta Delete iz comment-list.jsp
	@RequestMapping("/comment-delete")
	public String deleteComment(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		commentDAO.deleteComment(id);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/comment-list";
	}
	
	// sortiranje comentara
	@RequestMapping("/comment-sort")
	public String getCommentsSotr(Principal principal, @RequestParam int orderBy, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<Comment> commentsList = commentDAO.getCommentsByOrder(orderBy);
		model.addAttribute("commentList", commentsList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "comment-list";
	}
	
	// poziva se iz reservation-list sa dugmeta IS SEEN - (metoda STATUS komentara)
	@RequestMapping("/comment-status")
	public String getMarkCommentStatus(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		
		Comment comment = commentDAO.getComment(id);
		comment.setEnabled(!comment.getEnabled());
		commentDAO.saveComment(comment);
		
		return "redirect: comment-list";
	}
	
	
	/* MESSAGES */
	@RequestMapping("/message-list")
	public String getMessagesList(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		List<Messages> messagesList = messagesDAO.getMessagesList();
		model.addAttribute("messagesList", messagesList);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "message-list";
	}
	
	// # tokom izrade projekta postojala je stranice message-form.jsp #
	@RequestMapping("/message-form")
	public String getMessagesForm(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Messages message = new Messages();
		model.addAttribute("message",message);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "message-form";
	}

	// # tokom izrade projekta postojala je stranice message-form.jsp #
	// poziva sa dugmeta submit "Save message" iz message-form.jsp
	@RequestMapping("/message-save") // cuva (sejvuje) tag objekat prosledjen iz jsp stranice message-form
	public String saveMessage(Principal principal, /*@Valid*/ @ModelAttribute Messages message, Model model/*, BindingResult result*/) { 
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
	
		messagesDAO.saveMessage(message); // zavisno od id-ja, u messagesDAOImpl. cuva ili menja name
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/message-list"; // redirekcija dopunjuje putanju od root-a
	}

	// # tokom izrade projekta postojala je stranice message-form.jsp #
	// poziva se sa dugmeta Update iz message-form.jsp
	@RequestMapping("/message-form-update")
	public String getMessageUpdateForm(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Messages message = messagesDAO.getMessage(id);	// uzima objekat pod zadatim id-jem
		model.addAttribute("message",message); // kad otvorimo formu, preko kez-a ispisuje ime message-a koji treba da se menja
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "message-form";
	}	
	
	// poziva se sa dugmeta Delete iz message-list.jsp
	@RequestMapping("/message-delete")
	public String deleteMessage(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		messagesDAO.deleteMessage(id);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/message-list";
	}	
	 
	// poziva se iz reservation-list sa dugmeta IS SEEN - (metoda IS SEEN poruka)
	@RequestMapping("/message-seen")
	public String getMarkMessageSeen(Principal principal, @RequestParam int id, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		Messages message = messagesDAO.getMessage(id);
		// obelezava da je poruka pogledana i stavnja 1 (true) u tabelu
		message.setIsSeen(true);		
		messagesDAO.saveMessage(message);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect: message-list";
	}
	
	
	// USER
	@RequestMapping("/user-form")
	public String getUserForm(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		model.addAttribute("user", new User());
		model.addAttribute("roles", userDAO.getRoles());
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "user-form";
	}
	
	@RequestMapping("/user-save")
	public String saveUser(Principal principal, @ModelAttribute User user, Model model) {
		// uzimamo usera iz baze
		User logeduser = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", logeduser);

		String passwordEncode = new BCryptPasswordEncoder().encode(user.getPassword());

		user.setPassword("{bcrypt}"+passwordEncode);

		userDAO.saveUser(user);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/user-list";
	}
	
	@RequestMapping("/user-delete")
	public String deleteUser(Principal principal, @RequestParam String username, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		userDAO.deleteUser(username);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/user-list";
	}
	
	@RequestMapping("/user-list")
	public String getUserListPage(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		model.addAttribute("userList",userDAO.getUserList());
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "user-list";
	}

	@RequestMapping("/user-enable")
	public String enableUser(Principal principal, @RequestParam String username, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		userDAO.enableUser(username);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/user-list";
	}
	
	// radi isto kao save, samo ne tretira password
	@RequestMapping("/user-edit")
	public String getUserEdit(Principal principal, @ModelAttribute User user, Model model) {
		// uzimamo usera iz baze
		User logeduser = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", logeduser);
		
		userDAO.saveUser(user);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "redirect:/admin/user-list";
	}	
	
	@RequestMapping("/user-edit-profile")
	public String getUserEditProfile(Principal principal, Model model) {
		// uzimamo usera iz baze - principal - je onaj koji je trenutno ulogovan
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);

		model.addAttribute("user", user);
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "/user-edit-profile";
	}
	
	@RequestMapping("/user-change-password")
	public String getUserChangePassword(Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("user", user);
		// salje podatke za ulogovanog usera
		model.addAttribute("logedUser", user);

		// prosledjuje novi prazan objekat
		model.addAttribute("changePassword", new ChangePassword());
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());		
		return "/user-change-password";
	}
	
	@RequestMapping("/user-change-password-action")
	public String getUserChangePasswordAction(@ModelAttribute ChangePassword changePassword, Principal principal, Model model) {
		// uzimamo usera iz baze
		User user = userDAO.getUserByUsername(principal.getName());
		model.addAttribute("logedUser", user);
		
		model.addAttribute("unreadedMessCount",messagesDAO.getUnreadMessagesCount());	
		
		// da li se poklapaju novi i potvrdjeni novi password
		if(changePassword.getNewPassword().equalsIgnoreCase(changePassword.getConfirmPassword())){

			// pravi B encoder objekat
			BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();
			// da li se poklapaju stari password iz baze i koji je sad upisan
			if(encoder.matches(changePassword.getOldPassword(), user.getPassword().replace("{bcrypt}", ""))) {
				// ako se slazu passwordi, unosi novi password
				user.setPassword("{bcrypt}"+encoder.encode(changePassword.getNewPassword()));
				userDAO.saveUser(user);		
			} else {
				// ako nije unet dobro stari password
				// proslediti podatak o greki preko modela ili validatora i binding resut-a
				return "/user-change-password";
			}
			
		} else {
			// ne poklapaju se novi passwordi, new i confirm
			// proslediti podatak o greki preko modela ili validatora i binding resut-a
			return "/user-change-password";
		}
		

		return "redirect:/admin/user-list";
	}
	
	// radi isto kao save, samo ne tretira password
	@RequestMapping("/go-to-front")
	public String getGoToFront(Model model) {		
			
		
		model.addAttribute("slideitems",slideitemDAO.getSlideItemEnabled()); //salje slajdove koje se prikazuju
		model.addAttribute("blogs",blogDAO.getBlogsIsOnPageImpTop4()); //salje blogove koji su cekirani da se prikazuju
		
		//priprema 4 grupe po 3 bloga za prikaz na slajdu
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
		
		return "redirect:/index-page";
	}

	

}
