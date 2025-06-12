package blogzp.main.dao;

import java.util.List;

import blogzp.main.entity.Blog;

public interface BlogDAO {
	    // daje listu svih blogova
		public List<Blog> getBlogList();
		// cuva blogove
		public void saveBlog(Blog blog);
		// daje jedan blog po prosledjenom id-ju
		public Blog getBlog(int id);
		// brisanje zadatog bloga
		public void deleteBlog(int id);
		
		public List<Blog> getBlogsIsOnPage();
		
		public List<Blog> getBlogsIsOnPageImpTop4();
		
		public List<Blog> getBlogsIsOnPageImpTop3();
		
		public List<Blog> getBlogsIsOnPageTop3();
		
		public List<Blog> getBlogsIsOnPageTop12();
		
		// veza ManyToMany - pa mora EAGER, jer se objekat blog se ne puni odgovarajucim tagovima
		public Blog getBlogWithTag(int id);
		
		public List<Blog> getBlogListByTag(int id);
		
		// veza OneToMany
		public List<Blog> getBlogListByCategory(int id);
		// veza OneToMany
		public List<Blog> getBlogListByAuthor(String username);
		
		// sortiranje blogova
		public List<Blog> getBlogByOrder(int orderBy);
		
		// pretraga SEARCH
		public List<Blog> getPostSearch(String keyword);

}
