'use strict';

let functions = require('./functions');
//let maps = require('./maps');

let app = {
	init: function () {
		// call your functions here
		functions.swAtleteSlider();
		functions.swCrewCitySlider();
		functions.eventsSlider();
		functions.citiesMapSlider();
		functions.goToTop();
		functions.athletePopup();
		functions.crewPopup();
		functions.menuToggle();
		// if($('.sw-map-container').length) {
		// 	maps.initMap();
		// }

		// checking for touch devices, to prevent double tap and hover issues
		if(('ontouchstart' in window || navigator.msMaxTouchPoints > 0) && window.matchMedia('screen and (max-width: 1024px)').matches) {
			$('html').addClass('touch');
		} else {
			$('html').addClass('no-touch');
		}
	},
	winLoad: function () {
		// call functions that are needed for window load
		console.log('window loaded');
	},
	winResize: function () {
		// call functions that are needed on window resize
		console.log('window resized');
	}
};

$(function() {
	app.init();
});

$(window).on('load', function() {
	app.winLoad();
});

$(window).on('resize', function() {
	app.winResize();
});
