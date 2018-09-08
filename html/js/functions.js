'use strict';

module.exports = {

	initSlider: function() {
		let $slider = $('.slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick();
		}
	},

	swAtleteSlider: function() {
		let $slider = $('.sw-atlete-list');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 3,
				slidesToScroll: 1,
				infinite: false,
				arrows: true,
				dots: false,
				prevArrow: '<button class="slick-prev" type="button"><span class="icon font-ico-chevron-left"></span></button>',
				nextArrow: '<button class="slick-next" type="button"><span class="icon font-ico-chevron-right"></span></button>'
			});
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
