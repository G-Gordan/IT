package blogzp.main.dao;

import java.util.List;

import blogzp.main.entity.SlideItem;

public interface SlideItemDAO {
	
		// daje listu svih slajd itema
		public List<SlideItem> getSlideItemList();
		// poredjano po numerisanju - za sad NE ISKORISCENO..
		public List<SlideItem> getSlideItemListByNum();
		// cuva slajd iteme
		public void saveSlideItem(SlideItem slideItem);
		// daje jedan slajd item po prosledjenom id-ju
		public SlideItem getSlideItem(int id);
		// brisanje zadatog slajd itema
		public void deleteSlideItem(int id);
		// daje slajd item cekirane za prikazivanje
		public List<SlideItem> getSlideItemEnabled();

}
