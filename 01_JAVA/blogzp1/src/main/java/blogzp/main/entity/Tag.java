package blogzp.main.entity;

import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.Table;
//import blogzp.main.entity.Blog;

@Entity
@Table(name = "tag")
public class Tag {
	
	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	private int id;
	@Column
	private String name;
	@ManyToMany
	@JoinTable(name="blog_tag", joinColumns = @JoinColumn(name="idTag"), inverseJoinColumns = @JoinColumn(name="idBlog"))
	private List<Blog> blogs;
	
	public Tag() {
	}

	public Tag(String name) {
		super();
		this.name = name;
	}
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public List<Blog> getBlogs() {
		return blogs;
	}
	public void setBlogs(List<Blog> blogs) {
		this.blogs = blogs;
	}

	@Override
	public String toString() {
		return "(" + id + ") - " + name;
	}

}
