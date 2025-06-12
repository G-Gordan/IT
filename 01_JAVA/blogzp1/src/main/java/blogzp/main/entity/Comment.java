package blogzp.main.entity;

import java.time.LocalDateTime;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.persistence.Transient;

@Entity
@Table(name = "comments")
public class Comment {
	
	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	@Column
	private String comment;
	@Column
	private boolean enabled;
	//@Column
	@JoinColumn(name = "idBlog")
	@ManyToOne(cascade = {CascadeType.DETACH,CascadeType.MERGE,CascadeType.PERSIST,CascadeType.REFRESH})
	private Blog blog;
	@Column
	private String commName;
	@Column
	private LocalDateTime commDate;
	@Transient
	private String commDateTempForm;
	@Column
	private String email;
	@Transient
	private int postId;
	
	public Comment() {
		
	}

	public Comment(String comment, boolean enabled, Blog blog, String commName, LocalDateTime commDate, String commDateTempForm, String email) {
		super();
		this.comment = comment;
		this.enabled = enabled;
		this.blog = blog;
		this.commName = commName;
		this.commDate = commDate;
		this.commDateTempForm = commDateTempForm;
		this.email = email;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		// TEST...
		if (id == Integer.MAX_VALUE) {
			id = (Integer) null;
		}
		this.id = id;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

	public boolean getEnabled() {
		return enabled;
	}

	public void setEnabled(boolean enabled) {
		this.enabled = enabled;
	}	
	
	public Blog getBlog() {
		return blog;
	}

	public void setBlog(Blog blog) {
		this.blog = blog;
	}	

	public String getCommName() {
		return commName;
	}

	public void setCommName(String commName) {
		this.commName = commName;
	}

	public LocalDateTime getCommDate() {
		return commDate;
	}

	public void setCommDate(LocalDateTime commDate) {
		this.commDate = commDate;
	}
	
	public String getCommDateTempForm() {
		return commDateTempForm;
	}

	public void setCommDateTempForm(String commDateTempForm) {
		this.commDateTempForm = commDateTempForm;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Override
	public String toString() {
		// TODO Auto-generated method stub
		//return super.toString();
		return "(" + id + ") - " + comment;
	}
	
}
