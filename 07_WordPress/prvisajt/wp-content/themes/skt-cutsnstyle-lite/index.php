<?php
/**
 * The template for displaying home page.
 *
 * This is the template that displays all pages by default.
 * Please note that this is the WordPress construct of pages
 * and that other 'pages' on your WordPress site will use a
 * different template.
 *
 * @package SKT Cutsnstyle
 */

get_header(); 
?>
<?php if ( 'page' == get_option( 'show_on_front' ) && ( '' != get_option( 'page_for_posts' ) ) && $wp_query->get_queried_object_id() == get_option( 'page_for_posts' ) ) : ?>   
<div class="container">
     <div class="page_content">
        <section class="site-main">
        	 <div class="blog-post">
					<?php
                    if ( have_posts() ) :
                        // Start the Loop.
                        while ( have_posts() ) : the_post();
                            /*
                             * Include the post format-specific template for the content. If you want to
                             * use this in a child theme, then include a file called called content-___.php
                             * (where ___ is the post format) and that will be used instead.
                             */
                            get_template_part( 'content', get_post_format() );
                    
                        endwhile;
                        // Previous/next post navigation.
                        skt_cutsnstyle_pagination();
                    
                    else :
                        // If no content, include the "No posts found" template.
                         get_template_part( 'no-results', 'index' );
                    
                    endif;
                    ?>
                    </div><!-- blog-post -->
             </section>
      
        <?php get_sidebar();?>     
        <div class="clear"></div>
    </div><!-- site-aligner -->
</div><!-- content -->
<?php else: ?>

<section id="wrapfirst" class="pagewrap1">
        <div class="container">
                <?php 
		/*Home Section Content*/
		if( get_theme_mod('page-setting1')) { ?>
		<?php $queryvar = new WP_query('page_id='.get_theme_mod('page-setting1' ,true)); ?>
		<?php while( $queryvar->have_posts() ) : $queryvar->the_post();?> 
		
         <h1><?php the_title(); ?></h1>         
         <?php the_post_thumbnail();?>
		 <?php the_content(); ?>
         <div class="clear"></div>
        <?php endwhile; } else { ?>      
       <h1><?php _e('Dobro dosli','skt-cutsnstyle'); ?></h1>
       <p><?php _e('Zadovoljstvo klijenata na prvom mestu.','skt-cutsnstyle'); ?></p>
        <?php } ?>
        <div class="clear"></div>
         </div><!-- container -->
     </section><!-- #wrapfirst --> 
      <div class="clear"></div> 


       <section id="wrapsecond" class="pagewrap2">
            	<div class="container"> 
                 <h2 class="section_title"><?php echo get_theme_mod('threecols_title',__('Our Services','skt-cutsnstyle')); ?></h2>                   
                      <?php for($p=1; $p<4; $p++) { ?>       
        	<?php if( get_theme_mod('page-column'.$p,false)) { ?>          
        		<?php $queryxxx = new WP_query('page_id='.get_theme_mod('page-column'.$p,true)); ?>				
						<?php while( $queryxxx->have_posts() ) : $queryxxx->the_post(); ?> 
                        <div class="listpages <?php if($p % 3 == 0) { echo "last_column"; } ?>">                      
						<a href="<?php the_permalink(); ?>">
						<div class="services-thumb"><?php the_post_thumbnail('page-thumb');?></div>
                        <div class="services-content">
						  <h2><?php the_title(); ?></h2>						 
                          <?php echo skt_cutsnstyle_content(8); ?>
                        </div>
                        </a>
                        </div>
						<?php endwhile;
						wp_reset_query(); ?>
            <?php } else { ?>
					<div class="listpages <?php if($p % 3 == 0) { echo "last_column"; } ?>">                       
                        <a href="#">
                        <div class="services-thumb"><img src="<?php echo get_template_directory_uri(); ?>/images/about<?php echo $p; ?>.jpg" alt="" /></div> 
                        <div class="services-content">                     
						  <h2><?php _e('Page Title','skt-cutsnstyle'); ?> <?php echo $p; ?></h2>
						  <p><?php _e('Lorem ipsum dolor simpleit amet, consectetur adipiscing dummy elit.','skt-cutsnstyle'); ?></p>
                         </div>
                       </a>
                     </div>
			<?php }} ?>                     
             
              <div class="clear"></div>
            </div><!-- container -->
 </section><div class="clear"></div>
  
 <section id="FrontBlogPost" class="postwrap3">
  <div class="container">
  <h2 class="section_title"><?php _e('Latest Posts','skt-cutsnstyle'); ?></h2>       
     <div class="site-main">         
       <?php
	   $p = 0;
        global $wp_query;
        query_posts(array_merge($wp_query->query, array(
            'paged'          => get_query_var('paged'),
            'orderby' => 'title', 'order' => 'ASC' )));       
    ?>
       <?php global $wp_query; ?>
        <?php while( $wp_query->have_posts() ) : $wp_query->the_post(); ?><?php $p++; ?>      
            <div class="blog_lists BlogPosts <?php if( $p%3==0 ){?>last_column<?php } ?>">        
              <a title="<?php the_title(); ?>" href="<?php the_permalink(); ?>">
                <?php if( has_post_thumbnail() ) { ?>
                <?php the_post_thumbnail(); ?>
                <?php } else {  ?>
                <img src="<?php echo get_template_directory_uri(); ?>/images/img_404.png" alt="" />
                <?php } ?>
                </a>
               <h2><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h2>
              <div class="blog-meta"><?php echo get_the_date(); ?> | <?php comments_number(); ?></div>
              <?php echo skt_cutsnstyle_content(27); ?>
              <a class="MoreLink" href="<?php the_permalink(); ?>"><?php _e('Read more &raquo;','skt-cutsnstyle'); ?></a> 
              <div class="clear"></div>
          </div>       
        <?php endwhile; ?> 
        <?php skt_cutsnstyle_pagination(); ?>   
      <div class="clear"></div>
  </div> 
  <?php get_sidebar(); ?>
  <div class="clear"></div>
  </div><!-- .container -->   
 </section><!-- #FrontBlogPost -->  
<?php endif; ?>
<?php get_footer(); ?>