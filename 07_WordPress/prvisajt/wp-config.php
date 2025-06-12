<?php
/**
 * The base configuration for WordPress
 *
 * The wp-config.php creation script uses this file during the
 * installation. You don't have to use the web site, you can
 * copy this file to "wp-config.php" and fill in the values.
 *
 * This file contains the following configurations:
 *
 * * MySQL settings
 * * Secret keys
 * * Database table prefix
 * * ABSPATH
 *
 * @link https://codex.wordpress.org/Editing_wp-config.php
 *
 * @package WordPress
 */

// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define('DB_NAME', 'bazaprvisajt');

/** MySQL database username */
define('DB_USER', 'root');

/** MySQL database password */
define('DB_PASSWORD', '');

/** MySQL hostname */
define('DB_HOST', 'localhost');

/** Database Charset to use in creating database tables. */
define('DB_CHARSET', 'utf8mb4');

/** The Database Collate type. Don't change this if in doubt. */
define('DB_COLLATE', '');

/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define('AUTH_KEY',         'Cxk5)hYb1[1+f,.37IZ&04(zOz$zA8E^ TK{xG:S$%ztOt.o0;hE5z.N-^LW=YUI');
define('SECURE_AUTH_KEY',  '< </isX+fG!VBORvaQp?5]n9R),]:|PH2ZCZ%-XX#?dM+7{nOu(|%9.SPee$yU=5');
define('LOGGED_IN_KEY',    'Q]Wsm`U2]8[+bU&d~k `SzHn!CQr}b-BVqH<gV!i}ie<]U#o|-T,CM6?>R[>E#];');
define('NONCE_KEY',        '</%9:JO.B^k}AqD61`CaqQy],nfw]CF^IWou0_P1<Z]7l -C4yJ(,<j:ImR(&YiN');
define('AUTH_SALT',        'Gv5PnE-&hd>xZ:3(f2}8 %a^+{yCa}Cpg;?(r^yzbF:Q&EjN&A83zGf|LtTKWF,y');
define('SECURE_AUTH_SALT', 'g[9r;&Uk7Pevs:?[zmnpK56`vz6rOUjI}h2t=tWL{weEWZe#s-s9}-ALc >E#e?,');
define('LOGGED_IN_SALT',   'D.,0{pr{1Jvs^I0c<E~a]cj<[[IGrKMXY)Bx]DJ9dY!`GG^ou(bZ{}[pXk>WTjCH');
define('NONCE_SALT',       '}uS:cO~qdW}ddi0IRwEn[.(|vl`N=J?gtvB:ze?W%C}XsjTov0H8mFs(iPr9jC *');

/**#@-*/

/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each
 * a unique prefix. Only numbers, letters, and underscores please!
 */
$table_prefix  = 'wp_';

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 *
 * For information on other constants that can be used for debugging,
 * visit the Codex.
 *
 * @link https://codex.wordpress.org/Debugging_in_WordPress
 */
define('WP_DEBUG', false);

/* That's all, stop editing! Happy blogging. */

/** Absolute path to the WordPress directory. */
if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');

/** Sets up WordPress vars and included files. */
require_once(ABSPATH . 'wp-settings.php');
