'use strict';

let functions = require('./functions');
const listing = require('./listing');
const becomeMember = require('./become-member');
const athleteForm = require('./athlete-form');
const exerciseGroup = require('./exercise-group');
const athleteModule = require('./athlete-module');
const search = require('./search');
const newsletter = require('./newsletter');
const crewsModule = require('./crews-module');
const maps = require('./maps');

let app = {
	init: function () {
		// call your functions here
		functions.swAtleteSlider();
		functions.swCrewCitySlider();
		functions.eventsSlider();
		functions.citiesMapSlider();
		functions.goToTop();
		functions.fancyBox();
		functions.athletePopup();
		functions.selectCountry();
		functions.crewItemsPopup();
		functions.crewPopup();
		functions.parksScroll();
		functions.menuToggle();
		functions.showCookie();
		functions.hideCookie();
		listing.donators();
		becomeMember.changeImage();
		becomeMember.validatorSkip();
		becomeMember.changeBtn();
		athleteForm.showImagePreview();
		athleteForm.showFanImagePreview();
		athleteForm.showAchievementsInput();
		athleteForm.formInit();
		athleteForm.handleFormSubmit();
		athleteForm.hideCountryAndCityInput();
		athleteForm.previewImages();
		athleteForm.formChecked();
		athleteForm.fromAthletePage();
		exerciseGroup.exerciseGroups();
		exerciseGroup.exerciseDetail();
		exerciseGroup.sendRequest();
		athleteModule.filterAthletes();
		athleteModule.loadMore();
		search.search();
		newsletter.subscribe();
		crewsModule.chooseCrew();
		crewsModule.loadMoreCities();

		// checking for touch devices, to prevent double tap and hover issues
		if(('ontouchstart' in window || navigator.msMaxTouchPoints > 0) && window.matchMedia('screen and (max-width: 1024px)').matches) {
			$('html').addClass('touch');
		} else {
			$('html').addClass('no-touch');
		}
	},
	winLoad: function () {

	},
	winResize: function () {

	}
};

window.initMap = function () {
	window.initMap = null;
	if ($('.sw-map-container').length) {
		maps.initMap();
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
