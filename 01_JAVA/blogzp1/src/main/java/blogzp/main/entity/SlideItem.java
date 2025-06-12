package blogzp.main.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "slide_item")

public class SlideItem {

	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	@Column
	private String image;
	@Column
	private String itemTitle;
	@Column
	private String bTitle;	// button title
	@Column
	private String bLink;	// button link
	@Column
	private int numbering;	
	@Column
	private boolean enabled;
	
	public SlideItem() {
		
	}

	public SlideItem(String image, String itemTitle, String bTitle, String bLink, int numbering, boolean enabled) {
		super();
		this.image = image;
		this.itemTitle = itemTitle;
		this.bTitle = bTitle;
		this.bLink = bLink;
		this.numbering = numbering;
		this.enabled = enabled;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getItemTitle() {
		return itemTitle;
	}

	public void setItemTitle(String itemTitle) {
		this.itemTitle = itemTitle;
	}

	public String getbTitle() {
		return bTitle;
	}

	public void setbTitle(String bTitle) {
		this.bTitle = bTitle;
	}

	public String getbLink() {
		return bLink;
	}

	public void setbLink(String bLink) {
		this.bLink = bLink;
	}

	public int getNumbering() {
		return numbering;
	}

	public void setNumbering(int numbering) {
		this.numbering = numbering;
	}

	public boolean getEnabled() {
		return enabled;
	}

	public void setEnabled(boolean enabled) {
		this.enabled = enabled;
	}
	
	
	@Override
	public String toString() {
		return "(" + id + ") - " + itemTitle + " - " + image;
	}
	
}
