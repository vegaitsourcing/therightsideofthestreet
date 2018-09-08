'use strict';

module.exports = {

	initSlider: function() {
		let $slider = $('.slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick();
		}
	},

	swAtleteSlider: function() {
		let $slider = $('.sw-atlete-slider');
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

	swCrewCitySlider: function() {
		let $slider = $('.sw-crews-list');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 6,
				slidesToScroll: 1,
				infinite: false,
				arrows: true,
				dots: false,
				prevArrow: '<button class="slick-prev" type="button"><span class="icon font-ico-chevron-left"></span></button>',
				nextArrow: '<button class="slick-next" type="button"><span class="icon font-ico-chevron-right"></span></button>'
			});
		}
	},

	eventsSlider: function() {
		let $slider = $('.events-slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 3,
				slidesToScroll: 3,
				infinite: true,
				arrows: false,
				dots: true,
				autoplay: true,
				autoplaySpeed: 5000
			});
		}
	},

	citiesMapSlider: function() {
		let $slider = $('.sw-map-cities');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 6,
				slidesToScroll: 1,
				infinite: false,
				arrows: true,
				dots: false,
				prevArrow: '<button class="slick-prev" type="button"><span class="icon font-ico-chevron-left"></span></button>',
				nextArrow: '<button class="slick-next" type="button"><span class="icon font-ico-chevron-right"></span></button>'
			});
		}
	},

	goToTop: function() {
		$('.go-to-top').on('click', function() {
			$('html, body').animate({ scrollTop: 0}, 1000);
		});
	},

	athletePopup: function() {
		const swItem = $('.sw-atlete-item');
		swItem.find('.thumbnail, .sw-atlete-info h4 a').on('click', function() {
			const $swAtl = $(this).closest('.sw-atlete-item');
			const $popup = $swAtl.find('.sw-athlete-popup');
			if($popup.length) {
				$popup.slideDown(400, function() {
					$('html, body').animate({ scrollTop: $popup.offset().top }, 400);
					$swAtl.css('margin-bottom', $popup.outerHeight() + 150);
					$popup.addClass('opened');
				});
			}
		});
		$('.btn-close-popup').on('click', function() {
			const $popup = $(this).closest('.sw-athlete-popup');
			const $swAtl = $(this).closest('.sw-atlete-item');
			$popup.slideUp(300, function() {
				$swAtl.removeAttr('style').removeClass('opened');
				$('html, body').animate({ scrollTop: $swAtl.offset().top }, 400);
			});
		});
	}

};
