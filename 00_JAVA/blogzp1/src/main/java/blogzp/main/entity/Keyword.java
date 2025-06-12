package blogzp.main.entity;

import javax.validation.constraints.Size;

public class Keyword {
	
	@Size(max=1000, message="max 1000 characters")
	private String keyword;
	
	public Keyword() {
		
	}

	public Keyword(String keyword) {
		super();
		this.keyword = keyword;
	}

	public String getKeyword() {
		return keyword;
	}

	public void setKeyword(String keyword) {
		this.keyword = keyword;
	}
	
	@Override
	public String toString() {
		return keyword;
	}

}
