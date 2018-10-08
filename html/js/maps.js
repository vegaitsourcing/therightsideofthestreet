'use strict';

module.exports = {

	map: '',
	// array of categories taken from checkboxes name attribute
	categories: [],
	// array of projects with color, category, latitude and longitude
	projects: [],
	// array of projects that should be shown depending on checkbox selection
	showProjects: [],
	// array of markers to be displayed on the map, also depending on checkbox selection
	markers: [],

	infoWindow: '',

	bindCheckboxEvents: function() {
		let that = this;
		// clicking on checkboxes will check which categories are selected and it will render the map with new markers
		$('.project-filters input[type="checkbox"]').on('change', function (e) {
			that.getAllCategories();
			that.renderProjects();
			that.renderProjectItems();
		});
	},

	getAllCategories: function() {
		let that = this;
		// pulling the checked categories on page load and checkboxes selection
		$('.project-filters input[type="checkbox"]').each(function() {
			let catName = $(this).attr('name');
			// on checkbox change, if this category exists in the "categories" array, it is being removed from the array
			if(that.categories.indexOf(catName) !== -1) {
				that.categories.splice(that.categories.indexOf(catName), 1);
			}
			// on checkbox change, if the checkbox is checked, this category is added to the "categories" array
			if($(this).is(':checked')) {
				that.categories.push(catName);
			}
		});
	},

	getProjectsData: function() {
		let that = this;
		// collecting all the data from printed projects
		$('.project-filter-items').find('.accordion-row').each(function() {
			let color = $(this).data('project-color'),
				category = $(this).data('project-category'),
				latitude = $(this).data('project-latitude'),
				longitude = $(this).data('project-longitude'),
				popupText = $(this).find('.project-popup').html();

			// and adding the data into "projects" array
			that.projects.push({
				color: color,
				category: category,
				latitude: latitude,
				longitude: longitude,
				popupText: popupText
			});
		});
	},

	renderMap: function() {
		let latitude = 55.864237,
			longitude = -4.251806,
			zoomLvl = 8;

		if($(window).width() < 768) {
			zoomLvl = 7;
		}

		// rendering the google map with already set position and zoom level
		let mapOptions = {
			center: new google.maps.LatLng(latitude, longitude),
			zoom: zoomLvl,
			draggable: true,
			disableDefaultUI: true,
			mapTypeId: google.maps.MapTypeId.ROADMAP,
			mapTypeControlOptions: {
				style: google.maps.ZoomControlStyle.SMALL,
				position: google.maps.ControlPosition.TOP_RIGHT
			},
			styles: this.mapStyles
		};

		this.map = new google.maps.Map($('.module-map-container')[0], mapOptions);
	},

	renderProjects: function() {
		let that = this;
		// clearing the projects that should be shown, and then filling them up if the requirements are met
		that.showProjects = [];
		let extension = 'svg';

		let isIE = /*@cc_on!@*/false || !!document.documentMode;
		isIE ? extension = 'png' : extension = 'svg';

		// first we have to destroy every marker on the map, otherwise they would always be visible
		for (let j = 0; j < that.markers.length; j++) {
			that.markers[j].setVisible(false);
		}

		// go through every project and create a marker for it with required color, latitude and longitude
		for (let i = 0; i < that.projects.length; i++) {
			let project = that.projects[i];
			let marker = '';
			let icon = '';

			if($(window).width() < 768) {
				icon = new google.maps.MarkerImage('/images/pins/map-pin-' + project.color + '-mobile.' + extension,
					new google.maps.Size(23, 34),
					new google.maps.Point(0, 0),
					new google.maps.Point(11, 34));
			} else {
				icon = new google.maps.MarkerImage('/images/pins/map-pin-' + project.color + '.' + extension,
					new google.maps.Size(37, 56),
					new google.maps.Point(0, 0),
					new google.maps.Point(18, 56));
			}

			marker = new google.maps.Marker({
				position: new google.maps.LatLng(project.latitude, project.longitude),
				draggable: false,
				animation: google.maps.Animation.DROP,
				icon: icon,
				map: that.map
			});

			that.infoWindow = new google.maps.InfoWindow({
				maxWidth: 210
			});
			google.maps.event.addListener(marker, 'click', function () {
				let content = project.popupText;
				that.infoWindow.setContent(content);
				that.infoWindow.open(that.map, this);
			});

			// if categories to be visible contain this particular project, we push the project into the array, and it's relative marker to the markers array
			if(that.categories.indexOf(project.category) !== -1) {
				that.showProjects.push(project);
				that.markers.push(marker);
				marker.setVisible(true);
			} else {
				// hiding the markers if they don't belong to the categories array
				marker.setVisible(false);
			}
		}
	},

	initMap: function() {
		this.getAllCategories();
		this.getProjectsData();
		this.bindCheckboxEvents();
		this.renderMap();
		this.renderProjects();
	},

	mapStyles: [
		{
			"featureType": "administrative",
			"elementType": "labels",
			"stylers": [
				{
					"visibility": "simplified"
				}
			]
		},
		{
			"featureType": "landscape",
			"elementType": "geometry",
			"stylers": [
				{
					"saturation": "0"
				},
				{
					"lightness": "100"
				},
				{
					"gamma": "2.31"
				},
				{
					"visibility": "on"
				}
			]
		},
		{
			"featureType": "poi.park",
			"elementType": "geometry",
			"stylers": [
				{
					"visibility": "off"
				}
			]
		},
		{
			"featureType": "poi.park",
			"elementType": "labels",
			"stylers": [
				{
					"visibility": "off"
				}
			]
		},
		{
			"featureType": "road",
			"elementType": "geometry",
			"stylers": [
				{
					"saturation": "-100"
				},
				{
					"color": "#f5f5f5"
				}
			]
		},
		{
			"featureType": "road",
			"elementType": "labels.text",
			"stylers": [
				{
					"visibility": "simplified"
				},
				{
					"color": "#666666"
				}
			]
		},
		{
			"featureType": "road",
			"elementType": "labels.icon",
			"stylers": [
				{
					"visibility": "off"
				}
			]
		},
		{
			"featureType": "road.highway",
			"elementType": "geometry.stroke",
			"stylers": [
				{
					"visibility": "off"
				}
			]
		},
		{
			"featureType": "road.arterial",
			"elementType": "geometry.stroke",
			"stylers": [
				{
					"visibility": "off"
				}
			]
		},
		{
			"featureType": "water",
			"elementType": "geometry.fill",
			"stylers": [
				{
					"lightness": "50"
				},
				{
					"gamma": ".75"
				},
				{
					"saturation": "100"
				}
			]
		}
	]
};
