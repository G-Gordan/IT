package blogzp.main.dao;

import java.util.List;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import blogzp.main.entity.Comment;
import blogzp.main.entity.SlideItem;

@Repository
public class SlideItemDAOImplement implements SlideItemDAO{

	@Autowired
	private SessionFactory sessionFactory;

	@Transactional
	@Override
	public List<SlideItem> getSlideItemList() {
		Session session = sessionFactory.getCurrentSession();		
		Query<SlideItem> query = session.createQuery("FROM SlideItem",SlideItem.class);		
		List<SlideItem> slideItemsList = query.getResultList();		
		return slideItemsList;
	}
	
	// za sad NE ISKORISCENO...
	@Transactional
	@Override
	public List<SlideItem> getSlideItemListByNum() {
		Session session = sessionFactory.getCurrentSession();		
		Query<SlideItem> query = session.createQuery("SELECT s FROM SlideItem s ORDER BY s.numbering",SlideItem.class);		
		List<SlideItem> slideItemsList = query.getResultList();		
		return slideItemsList;
	}
	
	@Transactional
	@Override
	public void saveSlideItem(SlideItem slideItem) {
		Session session = sessionFactory.getCurrentSession();
		session.saveOrUpdate(slideItem);			
	}

	@Transactional
	@Override
	public SlideItem getSlideItem(int id) {
		Session session = sessionFactory.getCurrentSession();
		SlideItem slideItem = session.get(SlideItem.class, id);
		return slideItem;
	}

	@Transactional
	@Override
	public void deleteSlideItem(int id) {
		Session session = sessionFactory.getCurrentSession();
		Query query = session.createQuery("delete from SlideItem where id=:id");
		query.setParameter("id", id);
		query.executeUpdate();			
	}

	@Transactional
	@Override
	public List<SlideItem> getSlideItemEnabled() {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve cekirane slajd iteme
		Query<SlideItem> query = session.createQuery("SELECT s FROM SlideItem s WHERE s.enabled = 1 ORDER BY s.numbering",SlideItem.class);		
		List<SlideItem> list = query.getResultList();
	
		return list;
	}

}
