package blogzp.main.dao;

import java.util.List;

import blogzp.main.entity.Comment;

public interface CommentDAO {
	
	// daje jedan komentar po prosledjenom id-ju
	public Comment getComment(int id);
	// daje listu svih komentara
	public List<Comment> getCommentsList();
	// cuva komentare
	public void saveComment(Comment comments);
	// brisanje zadatog komentara
	public void deleteComment(int id);
	// daje komentare cekirane za prikazivanje
	public List<Comment> getCommentsEnabled();
	// daje listu svih komentara vezanij za odredjeni post
	public List<Comment> getCommentsPostList(int id);
	
	// sotriranje komentara
	public List<Comment> getCommentsByOrder(int orderBy);
}
