'use strict';

module.exports = {

	initSlider: function() {
		let $slider = $('.slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick();
		}
	},

	navigation: function() {
		const $header = $('[data-header]');
		const $nav = $('[data-navigation]');
		const $navToggle = $('[data-nav-toggle]');
		const navOpenedClass = 'nav--opened';
		const navigationOpenedClass = 'navigation--opened';
		const navToggleOpenedClass = 'nav__toggle--opened';

		$navToggle.on('click', function() {
			$(this).toggleClass(navToggleOpenedClass);
			$header.toggleClass(navigationOpenedClass);
			$nav.toggleClass(navOpenedClass);
		});
	}

};
