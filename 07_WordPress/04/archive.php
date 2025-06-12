
<!-- Header -->
<?php get_header(); ?>

				<!-- Main - sadržaj srane -->
					<div id="main">

						<!-- Posts -->
							<section class="posts">
								<?php while(have_posts()) { 
								 the_post() 
								
								 get_template_part('blocks/content','article');
								
								<!-- Pobrišemo sve ostale article -->
								  } //zatvara while
								  ?> 
							</section>

						<!-- Footer -->
							<!-- <footer> 
								<div class="pagination">
									<!--<a href="#" class="previous">Prev</a>
									<a href="#" class="page active">1</a>
									<a href="#" class="page">2</a>
									<a href="#" class="page">3</a>
									<span class="extra">&hellip;</span>
									<a href="#" class="page">8</a>
									<a href="#" class="page">9</a>
									<a href="#" class="page">10</a>
									<a href="#" class="next">Next</a>
								</div>
							</footer> -->

					</div>

<!-- Footer -->
<?php get_footer(); ?>
					