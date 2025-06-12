package blogzp.main.dao;


import java.util.List;

import blogzp.main.entity.Category;

public interface CategoryDAO {
	// daje listu svih kategorija
	public List<Category> getCategoryList();
	// cuva kategorije
	public void saveCategory(Category category);
	// daje jednu kategoriju po prosledjenom id-ju
	public Category getCategory(int id);
	// brisanje zadate kategorije
	public void deleteCategory(int id);
	// daje kategorije cekirane za naslovnu stranu
	public List<Category> getCategoriesIsOnPage();
	
	public List<Category> getCategoriesForFilter();
	
	// metoda koja uzima 4 kategorije koje su najvise povezane sa blogovima
	public List<Category> get4CategoriesMoreBlogs();

}
