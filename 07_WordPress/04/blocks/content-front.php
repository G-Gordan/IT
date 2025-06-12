
NEKI TEKST

<?php 

$argss = array(
        'numberposts'      => 2,
        'post_type'        => 'post',
        );
$upit = get_posts($args);
//var_dump($upit);
?>
<section class="posts>
<?php
//u po;etku je u foreach bila funkcija: the_title();
foreach($upit as $post) {
	setup_postdata($post);	
	get_template_part('blocks/content','article'); 
}
?>
</section>

<!-- 
'numberposts'      => 5, broj prokazanih postova
'category'         => 0, kategorija - može jedna poimence opisno
'orderby'          => 'date', - sort po
'order'            => 'DESC', - način sorta
'include'          => array(), - uključenje sadržaja
'exclude'          => array(), - ako želimo nešto da isključimo
'meta_key'         => '', - identifikuju dodatni sadržaj, pluginove, kao id sadržaja
'meta_value'       => '', - vrednost mete
'post_type'        => 'post', - daj mi sve postove, a može i tip 'page' da prikazuje sve stranice
'suppress_filters' => true,