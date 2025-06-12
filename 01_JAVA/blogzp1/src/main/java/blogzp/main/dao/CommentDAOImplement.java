package blogzp.main.dao;

import java.time.format.DateTimeFormatter;
import java.util.List;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.query.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import blogzp.main.entity.Blog;
import blogzp.main.entity.Comment;

@Repository
public class CommentDAOImplement implements CommentDAO{

	@Autowired
	private SessionFactory sessionFactory;

	@Transactional
	@Override
	public Comment getComment(int id) {
		Session session = sessionFactory.getCurrentSession();
		Comment comment = session.get(Comment.class, id);
		return comment;
	}

	@Transactional
	@Override
	public List<Comment> getCommentsList() {
		Session session = sessionFactory.getCurrentSession();		
		Query<Comment> query = session.createQuery("from Comment",Comment.class);		
		List<Comment> commentList = query.getResultList();
		return commentList;
	}

	@Transactional
	@Override
	public void saveComment(Comment comment) {
		Session session = sessionFactory.getCurrentSession();
		session.saveOrUpdate(comment);			
	}

	@Transactional
	@Override
	public void deleteComment(int id) {
		Session session = sessionFactory.getCurrentSession();
		Query query = session.createQuery("delete from Comment where id=:id");
		query.setParameter("id", id);
		query.executeUpdate();			
	}

	@Transactional
	@Override
	public List<Comment> getCommentsEnabled() {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve cekirane komentara
		Query<Comment> query = session.createQuery("select c from Comment c where c.enabled = 1",Comment.class);		
		List<Comment> list = query.getResultList();

		return list;
	}
	
	@Transactional
	@Override
	public List<Comment> getCommentsPostList(int id) {
		Session session = sessionFactory.getCurrentSession();
		// uzima sve cekirane komentara vezane za neki post
		Query<Comment> query = session.createQuery("from Comment c where c.blog.id = :id AND c.enabled = 1",Comment.class);		
		query.setParameter("id", id); // prvo id se prosledjuje u upit, a drugo je atribut iz prihvacen iz zagrade metode
		List<Comment> list = query.getResultList();
		// upisuje u polje objekta formatirano vreme kreiranja
		DateTimeFormatter myFormatObj = DateTimeFormatter.ofPattern("dd MMM yyyy");	    
		for(Comment c : list) {
			c.setCommDateTempForm(c.getCommDate().format(myFormatObj));
		}
		return list;
	}
	
	@Transactional
	@Override
	public List<Comment> getCommentsByOrder(int orderBy) {
		Session session = sessionFactory.getCurrentSession();		
		
		Query<Comment> query = null;
		if (orderBy == 0) { // by date created -> by id	
			query = session.createQuery("FROM Comment c ORDER BY c.id",Comment.class);			
		} else if (orderBy == 1) {  // by name
			query = session.createQuery("FROM Comment c ORDER BY c.blog.id",Comment.class);
		} else if (orderBy == 2) { // by price
			query = session.createQuery("FROM Comment c ORDER BY c.commName",Comment.class);
		} else if (orderBy == 3) { // by price
			query = session.createQuery("FROM Comment c ORDER BY c.commDate DESC",Comment.class);
		}
		
		List<Comment> commentList = query.getResultList();
		
		return commentList;
	}


}
