package blogzp.main.dao;

import java.util.List;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import blogzp.main.entity.Messages;

@Repository
public class MessagesDAOImplement implements MessagesDAO{

	@Autowired
	private SessionFactory sessionFactory;

	@Transactional
	@Override
	public Messages getMessage(int id) {
		Session session = sessionFactory.getCurrentSession();
		Messages message = session.get(Messages.class, id);
		return message;
	}

	@Transactional
	@Override
	public List<Messages> getMessagesList() {
		Session session = sessionFactory.getCurrentSession();		
		Query<Messages> query = session.createQuery("from Messages",Messages.class);		
		List<Messages> messagesList = query.getResultList();
		return messagesList;
	}

	
	@Transactional
	@Override
	public void saveMessage(Messages message) {
		Session session = sessionFactory.getCurrentSession();
		session.saveOrUpdate(message);				
	}

	@Transactional
	@Override
	public void deleteMessage(int id) {
		Session session = sessionFactory.getCurrentSession();
		Query query = session.createQuery("delete from Messages where id=:id");
		query.setParameter("id", id);
		query.executeUpdate();		
	}

	@Transactional
	@Override
	public List<Messages> getMessagesIsSeen() {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve cekirane poruke
		Query<Messages> query = session.createQuery("select m from Messages m where m.isSeen = 1",Messages.class);		
		List<Messages> list = query.getResultList();
		// prikazuje samo poruke koje su u okviru cekiranih da su procitane !
		return list;
	}
	
	// daje broj nepregledanih poruka za ikonicu gore desno
	@Transactional
	@Override
	public long getUnreadMessagesCount() {		
		Session session = sessionFactory.getCurrentSession();
		// selektuj i prebroj sve gde je isSeen = 0 (poruke koje jos nisu pogledane)
		Query query = session.createQuery("select count(*) from Messages m where m.isSeen = 0");
		//  katovanje u long i daj kao jedinstven rezultat
		return (long) query.uniqueResult();
	}

}
