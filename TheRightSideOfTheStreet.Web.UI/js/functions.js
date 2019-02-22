'use strict';

module.exports = {

	initSlider: function () {
		let $slider = $('.slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick();
		}
	},

	swAtleteSlider: function () {
		let $slider = $('.sw-atlete-slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 3,
				slidesToScroll: 1,
				infinite: false,
				arrows: true,
				dots: false,
				prevArrow: '<button class="slick-prev" type="button"><span class="icon font-ico-chevron-left"></span></button>',
				nextArrow: '<button class="slick-next" type="button"><span class="icon font-ico-chevron-right"></span></button>',
				responsive: [
					{
						breakpoint: 1024,
						settings: {
							slidesToShow: 2
						}
					},
					{
						breakpoint: 768,
						settings: {
							slidesToShow: 1
						}
					}
				]
			});
		}
	},

	swCrewCitySlider: function () {
		let $slider = $('.sw-crews-list');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 6,
				slidesToScroll: 1,
				infinite: false,
				arrows: true,
				dots: false,
				prevArrow: '<button class="slick-prev" type="button"><span class="icon font-ico-chevron-left"></span></button>',
				nextArrow: '<button class="slick-next" type="button"><span class="icon font-ico-chevron-right"></span></button>',
				responsive: [
					{
						breakpoint: 768,
						settings: {
							slidesToShow: 3
						}
					}
				]
			});
		}
	},

	eventsSlider: function () {
		let $slider = $('.events-slider');
		if ($slider !== undefined && $slider.length) {
			$slider.slick({
				slidesToShow: 3,
				slidesToScroll: 3,
				infinite: true,
				arrows: false,
				dots: true,
				autoplay: true,
				autoplaySpeed: 5000,
				responsive: [
					{
						breakpoint: 1024,
						settings: {
							slidesToShow: 2,
							slidesToScroll: 2,
						}
					},
					{
						breakpoint: 768,
						settings: {
							slidesToShow: 1,
							slidesToScroll: 1,
						}
					}
				]
			});
		}
	},

	citiesMapSlider: function () {
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

	goToTop: function () {
		$('.go-to-top').on('click', function () {
			$('html, body').animate({ scrollTop: 0 }, 1000);
		});
	},

	fancyBox: function () {
		$('[data-fancybox="gallery"]').fancybox({
			// 'width': 600, //or whatever you want
			// 'height': 300
		});
	},

	athletePopup: function () {
		const swItem = $('.sw-atlete-item');
		swItem.find('.thumbnail, .sw-atlete-info h4 a').on('click', function () {
			const $swAtl = $(this).closest('.sw-atlete-item');
			const $popup = $swAtl.find('.sw-athlete-popup');
			if ($popup.length) {
				$popup.slideDown(400, function () {
					$('html, body').animate({ scrollTop: $popup.offset().top }, 400);
					$swAtl.css('margin-bottom', $popup.outerHeight() + 150);
					$popup.addClass('opened');
				});
			}
		});
		$('.btn-close-popup').on('click', function () {
			const $popup = $(this).closest('.sw-athlete-popup');
			const $swAtl = $(this).closest('.sw-atlete-item');
			$popup.slideUp(300, function () {
				$swAtl.removeAttr('style').removeClass('opened');
				$('html, body').animate({ scrollTop: $swAtl.offset().top }, 400);
			});
		});
	},

	selectCountry: function () {
		$(function () {
			$('#country').change(function () {
				let countryKey = $('option:selected').data('key');
				$('.sw-crews-country').hide();

				let $countryLoadButtton = $('#load-' + countryKey);

				if ($countryLoadButtton.data('shown') === 0) {
					$('#load-' + countryKey).click();
				}

				$('#' + $(this).val()).find('.sw-crews-crew-list').hide();
				$('#' + $(this).val()).find('.workout-crew-popup').hide();
				$('#' + $(this).val()).show();
				$('#' + $(this).val()).find('.sw-crews-city-list').show();
			});
		});
	},

	crewItemsPopup: function () {
		$('.sw-crews-city-item').on('click', function () {
			$(this).closest('.sw-crews-city-list').slideUp(300);
			$(this).closest('.wrap').find('.sw-crews-crew-list').slideDown(300);
		});
		$('.back-to-wrap').on('click', function () {
			$(this).closest('.sw-crews-crew-list').slideUp(300);
			$(this).closest('.wrap').find('.sw-crews-city-list').slideDown(300);
			$(this).closest('.sw-crews').find('.workout-crew-popup').slideUp(300);
		});
	},

	crewPopup: function () {
		$('.sw-crews-crew-item').on('click', function () {

			const $this = $(this);
			const itemKey = $this.data("crew-key");
			const $item = $("div.wrap[data-crew-key=" + itemKey + "]");

			if (!$item) return;
			$item.siblings("div.wrap[data-crew-key]").hide();
			$item.show();
			$('.slick-slider').slick('refresh');

			$(this).closest('.sw-crews').find('.workout-crew-popup').slideDown(600);
			let headerHeight = $('.header').height();
			let $slider = $('.crew-popup-slider');
			if ($slider !== undefined && $slider.length) {
				$slider.not('.slick-initialized').slick({
						slidesToShow: 1,
						slidesToScroll: 1,
						infinite: false,
						arrows: true,
						dots: false,
						prevArrow: '<button class="slick-prev" type="button"><span class="icon font-ico-chevron-left"></span></button>',
						nextArrow: '<button class="slick-next" type="button"><span class="icon font-ico-chevron-right"></span></button>',
						responsive: [
							{
								breakpoint: 1024,
								settings: {
									slidesToShow: 1
								}
							},
							{
								breakpoint: 768,
								settings: {
									slidesToShow: 1
								}
							}
					]
				});
			}
			if ($(window).width() < 1025) {
				setTimeout(function () {
					$('html, body').animate({
						scrollTop: $(".workout-crew-popup").offset().top - headerHeight
					}, 500);
				}, 500);
			}
			else {
				setTimeout(function () {
					$('html, body').animate({
						scrollTop: $(".workout-crew-popup:visible").offset().top
					}, 500);
				}, 500);
			}
		});

		$('.btn-close-crew-popup').on('click', function () {
			$(this).closest('.workout-crew-popup').slideUp(300);
		});			
	},

	parksScroll: function () {
		const $parks = $('[swParks]');
		const header = $('.header').height();
		if (location.hash === '#sw-parks') {
			$('html, body').animate({
				scrollTop: $(".sw-maps").offset().top
			}, 1000);
		}

		$parks.click(function () {
			if ($(window).width() < 1025) {
				$('html, body').animate({
					scrollTop: $(".sw-maps").offset().top - header
				}, 500);
			}
			else {
				$('html, body').animate({
					scrollTop: $(".sw-maps").offset().top
				}, 500);
			}
			});
	},

	menuToggle: function () {
		const $menu = $('[data-menu]');
		const $menuToggle = $('[data-menu-toggle]');
		const $menuClose = $('[data-menu-close]');

		const openClass = 'main-nav-open';

		$menuToggle.on('click', function () {
			$menu.addClass(openClass);
		});

		$menuClose.on('click', function () {
			$menu.removeClass(openClass);
		});
	}
};
