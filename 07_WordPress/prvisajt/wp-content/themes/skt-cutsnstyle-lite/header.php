<?php
/**
 * The Header for our theme.
 *
 * Displays all of the <head> section and everything up till <div class="container">
 *
 * @package SKT Cutsnstyle
 */
?><!DOCTYPE html>
<html <?php language_attributes(); ?>>
<head>
<meta charset="<?php bloginfo( 'charset' ); ?>">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="profile" href="http://gmpg.org/xfn/11">
<link rel="pingback" href="<?php bloginfo( 'pingback_url' ); ?>">
<?php wp_head(); ?>

</head>

<body <?php body_class(''); ?>>
<div class="header">  
        <div class="header-inner">
                <div class="logo">
                        <a href="<?php echo esc_url( home_url('/') ); ?>">
                                <h1><?php bloginfo('name'); ?></h1>
                                <span class="tagline"><?php bloginfo( 'description' ); ?></span>                          
                        </a>                      
                 </div><!-- logo --> 
                 <div class="headerright">
                 <?php if ( ! dynamic_sidebar( 'sidebar-header' ) ) : ?>
                 <div class="ph-email-colmn">
                   <?php if( get_theme_mod('contact_no', '(0712) 456 9190') ) { ?>
                    <span class="phoneno"><?php echo get_theme_mod('contact_no', '(0712) 456 9190'); ?></span>
                  <?php } ?>
                  
                  <?php if( get_theme_mod('contact_mail', 'contact@company.com') ) { ?>
                    <a href="mailto:<?php echo get_theme_mod('contact_mail','contact@company.com'); ?>"><span class="emailicon"><?php echo get_theme_mod('contact_mail', 'contact@company.com'); ?></span></a>
                  <?php } ?>                 
                 </div>
                  <div class="appoint-colmn">                  
                    <?php if ( get_theme_mod('appointbutton_link', '#') ) { ?> 
                    <a title="Book an Appointment" class="bookbutton" href="<?php echo esc_url(get_theme_mod('appointbutton_link','#')); ?>">Book an Appointment</a>
                    <?php } ?>                               
                 </div> 
                 <?php endif; // end sidebar widget area ?>	                
                 <div class="clear"></div>
             </div><!-- .headerright -->
                 <div class="clear"></div> 
                <div class="toggle">
                <a class="toggleMenu" href="#"><?php _e('Menu','skt-cutsnstyle'); ?></a>
                </div><!-- toggle -->
                <div class="nav">                  
                    <?php wp_nav_menu( array('theme_location' => 'primary')); ?>
                </div><!-- nav -->
                    </div><!-- header-inner -->
</div><!-- header -->

<?php if ( is_front_page() && is_home() ) { ?>
<section id="home_slider">
        	<?php
			$sldimages = ''; 
			$sldimages = array(
						'1' => get_template_directory_uri().'/images/slides/slider1.jpg',
						'2' => get_template_directory_uri().'/images/slides/slider2.jpg',
						'3' => get_template_directory_uri().'/images/slides/slider3.jpg',
						'4' => get_template_directory_uri().'/images/slides/slider1.jpg',
						'5' => get_template_directory_uri().'/images/slides/slider2.jpg',								
			); ?>
            
        	<?php
			$slAr = array();
			$m = 0;
			for ($i=1; $i<6; $i++) {
				if ( get_theme_mod('slide_image'.$i, $sldimages[$i]) != "" ) {
					$imgSrc 	= get_theme_mod('slide_image'.$i, $sldimages[$i]);
					$imgTitle	= get_theme_mod('slide_title'.$i);
					$imgDesc	= get_theme_mod('slide_desc'.$i);
					$imgLink	= get_theme_mod('slide_link'.$i);
					if ( strlen($imgSrc) > 3 ) {
						$slAr[$m]['image_src'] = get_theme_mod('slide_image'.$i, $sldimages[$i]);
						$slAr[$m]['image_title'] = get_theme_mod('slide_title'.$i);
						$slAr[$m]['image_desc'] = get_theme_mod('slide_desc'.$i);
						$slAr[$m]['image_link'] = get_theme_mod('slide_link'.$i);
						$m++;
					}
				}
			}
			$slideno = array();
			if( $slAr > 0 ){
				$n = 0;?>
                <div class="slider-wrapper theme-default"><div id="slider" class="nivoSlider">
                <?php 
                foreach( $slAr as $sv ){
                    $n++; ?><img src="<?php echo esc_url($sv['image_src']); ?>" alt="<?php echo esc_attr($sv['image_title']);?>" title="<?php echo esc_attr('#slidecaption'.$n) ; ?>" /><?php
                    $slideno[] = $n;
                }
                ?>
                </div><?php
				
				
                foreach( $slideno as $sln ){ ?>
                    <div id="slidecaption<?php echo $sln; ?>" class="nivo-html-caption">
                    <div class="slide_info">
                    <h2><a href="<?php echo esc_url(get_theme_mod('slide_link'.$sln,'#link'.$sln)); ?>"><?php echo get_theme_mod('slide_title'.$sln, 'Create Your Hair Style with Us'); ?></a></h2>
                            <?php if( get_theme_mod('slide_desc'.$sln, '') ) { ?>
                              <p><?php echo get_theme_mod('slide_desc'.$sln, ''); ?></p>
                            <?php } ?>
                            
                           <?php if( get_theme_mod('slide_link'.$sln, '') ) { ?>
                              <a class="morelink" href="<?php echo esc_url(get_theme_mod('slide_link'.$sln,''.$sln)); ?>"><?php _e('Read More','skt-cutsnstyle'); ?></a>
                           <?php } ?>
                    </div>
                    </div><?php 
                } ?>
                </div>
                <div class="clear"></div><?php 
			}
            ?>           
        </section>	
	<?php
}elseif ( is_front_page() ) {
// Condition For Static Front Page
?>
<section id="home_slider">
        	<?php
			$sldimages = ''; 
			$sldimages = array(
						'1' => get_template_directory_uri().'/images/slides/slider1.jpg',
						'2' => get_template_directory_uri().'/images/slides/slider2.jpg',
						'3' => get_template_directory_uri().'/images/slides/slider3.jpg',
						'4' => get_template_directory_uri().'/images/slides/slider1.jpg',
						'5' => get_template_directory_uri().'/images/slides/slider2.jpg',								
			); ?>
            
        	<?php
			$slAr = array();
			$m = 0;
			for ($i=1; $i<6; $i++) {
				if ( get_theme_mod('slide_image'.$i, $sldimages[$i]) != "" ) {
					$imgSrc 	= get_theme_mod('slide_image'.$i, $sldimages[$i]);
					$imgTitle	= get_theme_mod('slide_title'.$i);
					$imgDesc	= get_theme_mod('slide_desc'.$i);
					$imgLink	= get_theme_mod('slide_link'.$i);
					if ( strlen($imgSrc) > 3 ) {
						$slAr[$m]['image_src'] = get_theme_mod('slide_image'.$i, $sldimages[$i]);
						$slAr[$m]['image_title'] = get_theme_mod('slide_title'.$i);
						$slAr[$m]['image_desc'] = get_theme_mod('slide_desc'.$i);
						$slAr[$m]['image_link'] = get_theme_mod('slide_link'.$i);
						$m++;
					}
				}
			}
			$slideno = array();
			if( $slAr > 0 ){
				$n = 0;?>
                <div class="slider-wrapper theme-default"><div id="slider" class="nivoSlider">
                <?php 
                foreach( $slAr as $sv ){
                    $n++; ?><img src="<?php echo esc_url($sv['image_src']); ?>" alt="<?php echo esc_attr($sv['image_title']);?>" title="<?php echo esc_attr('#slidecaption'.$n) ; ?>" /><?php
                    $slideno[] = $n;
                }
                ?>
                </div><?php
				
				
                foreach( $slideno as $sln ){ ?>
                    <div id="slidecaption<?php echo $sln; ?>" class="nivo-html-caption">
                    <div class="slide_info">
                    <h2><a href="<?php echo esc_url(get_theme_mod('slide_link'.$sln,'#link'.$sln)); ?>"><?php echo get_theme_mod('slide_title'.$sln, 'Splendid Days'); ?></a></h2>
                            <?php if( get_theme_mod('slide_desc'.$sln, '') ) { ?>
                              <p><?php echo get_theme_mod('slide_desc'.$sln, ''); ?></p>
                            <?php } ?>
                            
                           <?php if( get_theme_mod('slide_link'.$sln, '') ) { ?>
                              <a class="ReadMore" href="<?php echo esc_url(get_theme_mod('slide_link'.$sln,''.$sln)); ?>"><?php _e('Read More','skt-cutsnstyle'); ?></a>
                           <?php } ?>
                    </div>
                    </div><?php 
                } ?>
                </div>
                <div class="clear"></div><?php 
			}
            ?>           
        </section>
<?php
// Condition For Static Front Page >> Blog Page
} elseif ( is_home() ) { ?>
<div class="space30"></div>
<section id="home_slider" style="display:none;"></section>
<?php
// Condition For Other Page
} else {
			$header_image = get_header_image();
			if ( ! empty( $header_image ) ) {
				echo ' <div class="innerbanner"><img src="'.esc_url( $header_image ).'" width="'.get_custom_header()->width.'" height="'.get_custom_header()->height.'" alt="" /> </div>';
            }	
			else { 
            	echo '<div class="space30"></div>';
		    }  
}
?>		
        
 <?php if ( is_front_page() && ! is_home() ) { ?>
 
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
       <h1><?php _e('Welcome','skt-cutsnstyle'); ?></h1>
       <p><?php _e('Nunc faucibus velit ut tortor accumsan ultrices. Aliquam placerat libero vel pharetra placerat. Ut euismod elit id dui tincidunt rhont cusing. Proin pellentesque consequat finibus. Fusce pulvinar tortor sit amet ipsum lacinia, egestas mollis tortor scelerisque. Proin consequatted aliquet eleifend. Mauris laoreet ligula non metus tristique sodales. Pellentesque nec vehicula magna, sed convallis eros. Integer eget and dolor nunc. Nulla sem nibh, pellentesque ac posuere sit amet, lobortis eu nisi. Aliquam nulla ex, elementum ut porttitor vitae, tincidunt on vitae mauris.','skt-cutsnstyle'); ?></p>
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
        <?php } ?>