package blogzp.main.entity;

import java.time.LocalDateTime;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.ManyToMany;
import javax.persistence.ManyToOne;
//import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.validation.constraints.Size;

@Entity
@Table(name = "blog")

public class Blog {

	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	//@JoinTable(name = "comments",joinColumns = @JoinColumn(name = "id"),inverseJoinColumns = @JoinColumn(name = "idBlog"))
	//@OneToMany(cascade = CascadeType.ALL) // 
	private int id;	
	@Column
	private String blogText;	
	@Column
	@Size(min=20, max=255, message="min 20, max 255 characters")
	private String blogTitle;	
	@Column
	@Size(max=500, message="max 500 characters")
	private String description;
	@Column
	private String image;
	// prema polju tabele idCategory uzima ceo slog iz tabele i pravi objekat category kao polje u klasi i objektu blog
	@JoinColumn(name = "idCategory")
	@ManyToOne(cascade = {CascadeType.DETACH,CascadeType.MERGE,CascadeType.PERSIST,CascadeType.REFRESH})
	private Category category;
	// prema polju tabele idAuthor uzima ceo slog iz tabele i pravi objekat author kao polje u klasi i objektu blog
	@JoinColumn(name = "idAuthor")
	@ManyToOne(cascade = {CascadeType.DETACH,CascadeType.MERGE,CascadeType.PERSIST,CascadeType.REFRESH})
	private User author;
	@Column
	private boolean isOnPage;
	@Column
	private int reviewNumb;
	@Column
	private boolean isImportant;
	@Column
	private LocalDateTime blogCreated;
	@Transient
	private String blogCreatTempForm;
	@Transient
	private int commentNumb;
	//@Transient
	@JoinTable(name = "blog_tag",joinColumns = @JoinColumn(name = "idBlog"),inverseJoinColumns = @JoinColumn(name = "idTag"))
	@ManyToMany(cascade = {CascadeType.DETACH,CascadeType.MERGE,CascadeType.PERSIST,CascadeType.REFRESH})
	private List<Tag> tags;
	
	public Blog() {
		
	}

	public Blog(String blogText, String blogTitle, String description, String image, Category category,
			User author, boolean isOnPage, int reviewNumb, boolean isImportant, LocalDateTime blogCreated,
			String blogCreatTempForm, int commentNumb) {
		super();
		this.blogText = blogText;
		this.blogTitle = blogTitle;
		this.description = description;
		this.image = image;
		this.category = category;
		this.author = author;
		this.isOnPage = isOnPage;
		this.reviewNumb = reviewNumb;
		this.isImportant = isImportant;
		this.blogCreated = blogCreated;
		this.blogCreatTempForm = blogCreatTempForm;
		this.commentNumb = commentNumb;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getBlogText() {
		return blogText;
	}

	public void setBlogText(String blogText) {
		this.blogText = blogText;
	}

	public String getBlogTitle() {
		return blogTitle;
	}

	public void setBlogTitle(String blogTitle) {
		this.blogTitle = blogTitle;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public Category getCategory() {
		return category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}
	
	public User getAuthor() {
		return author;
	}

	public void setAuthor(User author) {
		this.author = author;
	}

	public boolean getIsOnPage() {
		return isOnPage;
	}

	public void setIsOnPage(boolean isOnPage) {
		this.isOnPage = isOnPage;
	}

	public int getReviewNumb() {
		return reviewNumb;
	}

	public void setReviewNumb(int reviewNumb) {
		this.reviewNumb = reviewNumb;
	}

	public boolean getIsImportant() {
		return isImportant;
	}

	public void setIsImportant(boolean isImportant) {
		this.isImportant = isImportant;
	}	

	public LocalDateTime getBlogCreated() {
		return blogCreated;
	}

	public void setBlogCreated(LocalDateTime blogCreated) {
		this.blogCreated = blogCreated;
	}
	
	public String getBlogCreatTempForm() {
		return blogCreatTempForm;
	}

	public void setBlogCreatTempForm(String blogCreatTempForm) {
		this.blogCreatTempForm = blogCreatTempForm;
	}
	
	public int getCommentNumb() {
		return commentNumb;
	}

	public void setCommentNumb(int commentNumb) {
		this.commentNumb = commentNumb;
	}

	public List<Tag> getTags() {
		return tags;
	}
	public void setTags(List<Tag> tags) {
		this.tags = tags;
	}

	
	@Override
	public String toString() {
		//return "(" + id + ") - " + blogTitle + " - " + author.getName();
		//return "(" + id + ") - " + tags;
		return "(" + id + ") - " + blogTitle;
	}	
}
