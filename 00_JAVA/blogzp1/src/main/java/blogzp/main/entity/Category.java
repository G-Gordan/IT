package blogzp.main.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Transient;

@Entity
@Table(name = "category")
public class Category {
	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	@Column
	private String name;
	@Column
	private boolean isOnPage;
	@Column
	private String image;
	@Column
	private String description;
	@Column
	private int numbering;
	@Transient
	private long count;
	
	public Category() {
		
	}
	
	public Category(String name, boolean isOnPage, String image, String description, int numbering, long count) {
		super();
		this.name = name;
		this.isOnPage = isOnPage;
		this.image = image;
		this.description = description;
		this.numbering = numbering;
		this.count = count;
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

	public boolean getIsOnPage() {
		return isOnPage;
	}

	public void setIsOnPage(boolean isOnPage) {
		this.isOnPage = isOnPage;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public int getNumbering() {
		return numbering;
	}

	public void setNumbering(int numbering) {
		this.numbering = numbering;
	}
	
	public long getCount() {
		return count;
	}
	
	public void setCount(long count) {
		this.count = count;
	}
	
	@Override
	public String toString() {
		return "(" + id + ") - " + name /*+ " posts: " + count*/;
	}
	

	

}
