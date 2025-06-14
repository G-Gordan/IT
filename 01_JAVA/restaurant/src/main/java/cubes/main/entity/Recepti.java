package cubes.main.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.Size;

@Entity
@Table
public class Recepti {
	
	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	@Column
	@Size(min=3, max=20, message="min 3, max 20 characters")
	private String name;
	@Column
	@Size(min=5, max=120, message="min 5, max 120 characters")
	private String description;
	
	public Recepti() {
	}	
	
	public Recepti(String name, String description) {
		super();
		this.name = name;
		this.description = description;
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
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}	

	@Override
	public String toString() {
		return "(" + id + ") - " + name;
	}
	
}
