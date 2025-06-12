package blogzp.main.dao;

import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import org.hibernate.Hibernate;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import blogzp.main.entity.Blog;
import blogzp.main.entity.Category;
import blogzp.main.entity.Tag;
import blogzp.main.dao.CommentDAO;


@Repository
public class BlogDAOImplement implements BlogDAO{
	@Autowired
	private SessionFactory sessionFactory;
	@Autowired
	private CommentDAO commentDAO;

	@Transactional
	@Override
	public List<Blog> getBlogList() {
		Session session = sessionFactory.getCurrentSession();		
		Query<Blog> query = session.createQuery("from Blog",Blog.class);		
		List<Blog> blogList = query.getResultList();

		return blogList;
	}

	@Transactional
	@Override
	public void saveBlog(Blog blog) {
		Session session = sessionFactory.getCurrentSession();
		session.saveOrUpdate(blog);			
	}

	@Transactional
	@Override
	public Blog getBlog(int id) {
		Session session = sessionFactory.getCurrentSession();
		Blog blog = session.get(Blog.class, id);
		return blog;
	}

	@Transactional
	@Override
	public void deleteBlog(int id) {
		Session session = sessionFactory.getCurrentSession();
		Query query = session.createQuery("delete from Blog where id=:id");
		query.setParameter("id", id);
		query.executeUpdate();			
	}

	@Transactional
	@Override
	public List<Blog> getBlogsIsOnPage() {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve blogove cekirane za prikaz na stranici
		Query<Blog> query = session.createQuery("SELECT b FROM Blog b WHERE b.isOnPage = 1 ORDER BY b.blogCreated DESC",Blog.class);		
		List<Blog> list = query.getResultList();
		
		// upisuje u polje objekta formatirano vreme kreiranja i broj komentara
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMMM yyyy");	    
		for(Blog b : list) {
			b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
			b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
		}
		
		return list;
	}
	
	@Transactional
	@Override
	public List<Blog> getBlogsIsOnPageImpTop4() {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve blogove cekirane za prikaz na stranici
		Query<Blog> query = session.createQuery("SELECT b FROM Blog b WHERE b.isOnPage = 1 AND b.isImportant = 1 ORDER BY b.id DESC",Blog.class);	

		List<Blog> listtemp = query.getResultList();
		
		List<Blog> listAL = new ArrayList<Blog>();
		// u novu listu unosi prva 4 elementa
		listAL = listtemp.stream().limit(4).collect(Collectors.toList());
		
		// upisuje u polje objekta formatirano vreme kreiranja, i broj komentara
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd-MMM-yyyy");	    
		for(Blog b : listtemp) {
			b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
			// postavlja broj komentara
			b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
		}
		
		return listAL; // AL
	}
	
	@Transactional
	@Override
	public List<Blog> getBlogsIsOnPageImpTop3() {
		Session session = sessionFactory.getCurrentSession();
		Query<Blog> query = session.createQuery("SELECT b FROM Blog b WHERE b.isOnPage = 1 AND b.isImportant = 1",Blog.class);	
		List<Blog> listtemp = query.getResultList();
		
		// SORTIRA da prvo idu sa najvecim brojem pregleda
		listtemp.sort(Comparator.comparing(Blog::getReviewNumb).reversed());
		
		List<Blog> listAL = new ArrayList<Blog>();
		// u novu listu unosi prva 3 elemnta iz stare...
		listAL = listtemp.stream().limit(3).collect(Collectors.toList());

		// unosi broj komentara
		for(Blog b : listAL) {
			// postavlja broj komentara
			b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
		}
		
		return listAL; // AL
	}
	
	@Transactional
	@Override
	public List<Blog> getBlogsIsOnPageTop3() {
		Session session = sessionFactory.getCurrentSession();
		Query<Blog> query = session.createQuery("SELECT b FROM Blog b WHERE b.isOnPage = 1 ORDER BY b.id DESC",Blog.class);	
		List<Blog> listtemp = query.getResultList();
				
		List<Blog> listAL = new ArrayList<Blog>();
		// u novu listu unosi prva 3 elementa
		listAL = listtemp.stream().limit(3).collect(Collectors.toList());

		// upisuje u polje objekta formatirano vreme kreiranja
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("MMMM dd, yyyy");	    
		for(Blog b : listtemp) {
			b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
		}
		
		return listAL; // AL
	}
	
	@Transactional
	@Override
	public List<Blog> getBlogsIsOnPageTop12() {
		Session session = sessionFactory.getCurrentSession();
		Query<Blog> query = session.createQuery("SELECT b FROM Blog b WHERE b.isOnPage = 1 ORDER BY b.id DESC",Blog.class);	
		List<Blog> listtemp = query.getResultList();
				
		List<Blog> listAL = new ArrayList<Blog>();
		// u novu listu unosi prvih 12 elemenata iz stare...
		listAL = listtemp.stream().limit(12).collect(Collectors.toList());

		// upisuje u polje objekta formatirano vreme kreiranja
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMMM | yyyy");	    
		for(Blog b : listtemp) {
			b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
		}
		
		return listAL; // AL
	}
	
	// uzimanje bloga zajedno sa tagovima
	@Transactional
	@Override
	public Blog getBlogWithTag(int id) {
		Session session = sessionFactory.getCurrentSession();
		Blog blog = session.get(Blog.class, id);
		Hibernate.initialize(blog.getTags()); // inicira LAZY ucitavanje tagova
		return blog;
	}
	
	// uzimanje postova po zadatam id-ju taga
	@Transactional
	@Override
	public List<Blog> getBlogListByTag(int id) { // filtrira za prosledjeni id taga
		Session session = sessionFactory.getCurrentSession();
		// za prosledjeni parametar id, preko sesije uzmi tag
		Tag tag = session.get(Tag.class, id);
		// posto je ManyToMany mora da podesi na LAZY
		Hibernate.initialize(tag.getBlogs());
		// iz tog taga posalji listu blogova obelezenih za prikaz na stranici
		List<Blog> listAll = tag.getBlogs();
		List<Blog> listOnPage = new ArrayList<Blog>();

		for(Blog b : listAll) {
			if(b.getIsOnPage() == true) {
				listOnPage.add(b);
			}
		}
		//return tag.getBlogs();
		return listOnPage;

	}
	
	// uzimanje postova po zadatam id-ju kategorije
	@Transactional
	@Override
	public List<Blog> getBlogListByCategory(int id) { //filtrira za prosledjen id kategorije
		Session session = sessionFactory.getCurrentSession();
		Query<Blog> query = session.createQuery("from Blog blog where blog.category.id = :id AND blog.isOnPage = 1",Blog.class); // :id je id iz zagrade (parametar)
		query.setParameter("id", id); // prvo id se prosledjuje dalje, a drugo je atribut iz prihvacen iz zagrade
		// vraca listu filtriranih parametara
		return query.getResultList();
	}
	
	// uzimanje postova po zadatom id-ju kategorije
	@Transactional
	@Override
	public List<Blog> getBlogListByAuthor(String username) { //filtrira za prosledjen id kategorije
		Session session = sessionFactory.getCurrentSession();
		Query<Blog> query = session.createQuery("from Blog blog where blog.author.username = :username AND blog.isOnPage = 1",Blog.class); // :username je username iz zagrade (parametar)
		query.setParameter("username", username); // prvi username se prosledjuje dalje, a drugo je atribut iz prihvacen iz zagrade
		
		List<Blog> listtemp = query.getResultList();
		
		// upisuje u polje objekta formatirano vreme kreiranja
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMMM, yyyy");	    
		for(Blog b : listtemp) {
			b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
			// postavlja broj komentara
			b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
		}
		
		// vraca listu filtriranih parametara
		return listtemp;
	}
	
	@Transactional
	@Override
	public List<Blog> getBlogByOrder(int orderBy) {
		Session session = sessionFactory.getCurrentSession();		
		
		Query<Blog> query = null;
		if (orderBy == 0) { // by date created -> by id	
			query = session.createQuery("from Blog b order by b.id",Blog.class);			
		} else if (orderBy == 1) {  // by name
			query = session.createQuery("from Blog b order by b.category.name",Blog.class);
		} else if (orderBy == 2) { // by price
			query = session.createQuery("from Blog b order by b.author.name",Blog.class);
		}
		
		List<Blog> blogList = query.getResultList();
		
		return blogList;
	}

	// uzimanje postova po zadatoj kljucnoj reci za pretragu...
	@Transactional
	@Override
	public List<Blog> getPostSearch(String keyword) {

		Session session = sessionFactory.getCurrentSession();
		
		Query<Blog> query = session.createQuery("SELECT b FROM Blog b " +
		"WHERE b.isOnPage = 1 AND b.isImportant = 1 " +
		"AND (LOWER(b.blogTitle) LIKE LOWER(CONCAT('%', :keyword, '%')) " +
		"OR LOWER(b.description) LIKE LOWER(CONCAT('%', :keyword, '%')) " +
		"OR LOWER(b.blogText) LIKE LOWER(CONCAT('%', :keyword, '%'))) " +
		"ORDER BY b.id DESC",Blog.class);
		query.setParameter("keyword", keyword);
		
		List<Blog> list = query.getResultList();

		// upisuje u polje objekta formatirano vreme kreiranja i broj komentara
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMMM yyyy");	    
		for(Blog b : list) {
			b.setBlogCreatTempForm(b.getBlogCreated().format(myFormatObj));
			// postavlja broj komentara
			b.setCommentNumb(commentDAO.getCommentsPostList(b.getId()).size());
		}

		return list;
	}

}
