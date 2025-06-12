package blogzp.main.dao;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import blogzp.main.entity.Category;

@Repository
public class CategoryDAOImplemet implements CategoryDAO{
	
	@Autowired
	private SessionFactory sessionFactory;

	@Transactional
	@Override
	public List<Category> getCategoryList() {
		Session session = sessionFactory.getCurrentSession();		
		Query<Category> query = session.createQuery("from Category",Category.class);		
		List<Category> categoryList = query.getResultList();		
		return categoryList;
	}

	@Transactional
	@Override
	public void saveCategory(Category category) {
		Session session = sessionFactory.getCurrentSession();
		session.saveOrUpdate(category);		
	}

	@Transactional
	@Override
	public Category getCategory(int id) {
		Session session = sessionFactory.getCurrentSession();
		Category category = session.get(Category.class, id);
		return category;
	}

	@Transactional
	@Override
	public void deleteCategory(int id) {
		Session session = sessionFactory.getCurrentSession();
		//Query<?> query = session.createQuery("delete from Category where id=:id");
		Query query = session.createQuery("delete from Category where id=:id");
		query.setParameter("id", id);
		query.executeUpdate();		
	}

	@Transactional
	@Override
	public List<Category> getCategoriesIsOnPage() {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve cekirane kategorije
		Query<Category> query = session.createQuery("select c from Category c where c.isOnPage = 1",Category.class);		
		List<Category> list = query.getResultList();

		return list;
	}
	
	@Transactional
	@Override
	public List<Category> getCategoriesForFilter() {
		Session session = sessionFactory.getCurrentSession();
		Query<Category> query = session.createQuery("from Category",Category.class);		
		List<Category> categoryList = query.getResultList();
		// treba da prebroji postove za sve kategorije
		for(Category cat : categoryList) {
			// prebroj mi sve postove od ovih kategorija, iz tabele Blog po zadatom id-ju kategorije.
			Query queryCount = session.createQuery("select count(blog.id) from Blog blog where blog.category.id = :id");
			// povezuje "id" iz kverija sa id-jem kategorije i da taj broj postavi u polje klase (ali ne i tabele!) "count"
			queryCount.setParameter("id", cat.getId());
			// id iz kverija uparuje sa idjem iz cat
			cat.setCount((long) queryCount.uniqueResult());
		}
		
		categoryList.sort(Comparator.comparing(Category::getCount).reversed());
		
		return categoryList;
	}
	
	// metoda koja uzima 4 kategorije koje su najvise povezane sa blogovima
	@Transactional
	@Override
	public List<Category> get4CategoriesMoreBlogs() {
		// daje listu kategorija sa brojevima postova sa kojima su povezani
		List<Category> categoryList4 = getCategoriesForFilter();
		// treba da poredja kategorije po najvecem broju blogova
		//Collections.reverse(categoryList4);
		categoryList4.sort(Comparator.comparing(Category::getCount).reversed());
		
		List<Category> categoryFirst4 = new ArrayList<Category>();
		// u novu listu unosi prva 4 elemnta
		categoryFirst4 = categoryList4.stream().limit(4).collect(Collectors.toList());
		
		return categoryFirst4;
	}
	

}
