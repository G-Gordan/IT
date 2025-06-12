<article>
		<header>
			<span class="date"><?php the_date('j F Y') ?></span>
			<h2><a href="#"><?php the_title() ?></a></h2>
		</header>
		<a href="#" class="image fit"><?php the_post_thumbnail() ?></a>
		<p><?php the_excerpt() ?></p>
		<ul class="actions special">
			<li><a href=<?php the_permalink() ?> class="button"><?php echo __('Detaljnije','gordan2') ?></a></li>
		</ul>
</article>