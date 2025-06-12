package blogzp.main.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "messages")
public class Messages {
	
	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	@Column
	private String name;
	@Column
	private String email;
	@Column
	private String messText;
	@Column
	private boolean isSeen;
	
	public Messages() {
		
	}

	public Messages(String name, String email, String messText, boolean isSeen) {
		super();
		this.name = name;
		this.email = email;
		this.messText = messText;
		this.isSeen = isSeen;
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

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getMessText() {
		return messText;
	}

	public void setMessText(String messText) {
		this.messText = messText;
	}

	public boolean getIsSeen() {
		return isSeen;
	}

	public void setIsSeen(boolean isSeen) {
		this.isSeen = isSeen;
	}
	
	
	@Override
	public String toString() {
		return "(" + id + ") - " + name;
	}
	
	
	

}


