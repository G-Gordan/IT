<?php
/**
 * The template for displaying the footer.
 *
 * Contains the closing of the #content div and all content after
 *
 * @package SKT Cutsnstyle
 */
?>
<div id="footer-wrapper">
    	<div class="container">
        
            <div class="cols-3 widget-column-1">  
            
             <h5><?php echo get_theme_mod('about_title',__('About Cut n Style','skt-cutsnstyle')); ?></h5>            	
				<p><?php echo get_theme_mod('about_description',__('Consectetur, adipisci velit, sed quiaony on numquam eius modi tempora incidunt, ut laboret dolore agnam aliquam quaeratine voluptatem. ut enim ad minima veniamting suscipit lab velit, sed quiaony on numquam eius.','skt-cutsnstyle')); ?></p>   
                
                 <div class="social-icons">
					<?php if ( get_theme_mod('fb_link') != "") { ?>
                    <a title="facebook" class="fb" target="_blank" href="<?php echo esc_url(get_theme_mod('fb_link','#facebook')); ?>"></a> 
                    <?php } else { ?>
                    <?php echo '<a href="#" target="_blank" class="fb" title="facebook"></a>'; } ?>
                    
                    <?php if ( get_theme_mod('twitt_link') != "") { ?>
                    <a title="twitter" class="tw" target="_blank" href="<?php echo esc_url(get_theme_mod('twitt_link','#twitter')); ?>"></a>
                    <?php } else { ?>
                    <?php echo '<a href="#" target="_blank" class="tw" title="twitter"></a>'; } ?> 
                    
                    <?php if ( get_theme_mod('gplus_link') != "") { ?>
                    <a title="google-plus" class="gp" target="_blank" href="<?php echo esc_url(get_theme_mod('gplus_link','#gplus')); ?>"></a>
                    <?php } else { ?>
                    <?php echo '<a href="#" target="_blank" class="gp" title="google-plus"></a>'; } ?>
                    
                    <?php if ( get_theme_mod('linked_link') != "") { ?> 
                    <a title="linkedin" class="in" target="_blank" href="<?php echo esc_url(get_theme_mod('linked_link','#linkedin')); ?>"></a>
                    <?php } else { ?>
                    <?php echo '<a href="#" target="_blank" class="in" title="linkedin"></a>'; } ?>
                  </div>          	
             
            </div><!--end .col-3-->
			         
             
             <div class="cols-3 widget-column-2">  
                <h5><?php echo get_theme_mod('recentpost_title',__('Recent Posts','skt-cutsnstyle')); ?></h5>            	
				<?php $args = array( 'posts_per_page' => 2, 'post__not_in' => get_option('sticky_posts'), 'orderby' => 'date', 'order' => 'desc' );
                    query_posts( $args ); ?>
                    
                  <?php while ( have_posts() ) :  the_post(); ?>
                        <div class="recent-post">
                         <a href="<?php the_permalink(); ?>"><?php the_post_thumbnail('thumbnail'); ?></a>
                         <a href="<?php the_permalink(); ?>"><h6><?php the_title(); ?></h6></a>                         
                         <?php echo skt_cutsnstyle_content(12); ?>                         
                        </div>
                 <?php endwhile; ?>
                          	
              </div><!--end .col-3-->
                      
               <div class="cols-3 widget-column-3">
               
                <h5><?php echo get_theme_mod('contact_title',__('Contact Info','skt-cutsnstyle')); ?></h5> 
                  <?php if( get_theme_mod('contact_add', '100 King St, Melbourne PIC 4000, Australia') ) { ?>
                    <span class="mapicon"><?php echo get_theme_mod('contact_add', '100 King St, Melbourne PIC 4000, <br> Australia'); ?></span>
                  <?php } ?>
				  
				  <?php if( get_theme_mod('contact_no', '(0712) 456 9190') ) { ?>
                    <span class="phoneno"><?php echo get_theme_mod('contact_no', '(0712) 456 9190'); ?></span>
                  <?php } ?>
                  
                  <?php if( get_theme_mod('contact_mail', 'contact@company.com') ) { ?>
                    <a href="mailto:<?php echo get_theme_mod('contact_mail','contact@company.com'); ?>"><span class="emailicon"><?php echo get_theme_mod('contact_mail', 'contact@company.com'); ?></span></a>
                  <?php } ?>
                  
                  
                    
                </div><!--end .col-3-->
                
            <div class="clear"></div>
         </div><!--end .container-->
              
            
       <div class="copyright-wrapper">
        	<div class="container">

                <div class="clear"></div>
            </div>
        </div>
      
    </div><!--end .footer-->
<?php wp_footer(); ?>

</body>
</html>