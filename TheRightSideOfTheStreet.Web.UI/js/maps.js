'use strict';

module.exports = {
	map: '',
	mapZoomOnClick: 12,
	parks: [],
	markers: [],
	filterSelector: '.js-cities-filter',
	filterButtonSelector: '.js-city-btn',

	infoWindow: {},

	initMap: function () {
		this.parks = this.getParks();
		this.renderMap();
		this.infoWindow = new google.maps.InfoWindow();
		this.renderParks();
		this.bindFilter();
	},

	getParks: function () {
		const parks = [];

		$('[data-park-name]').each(function() {
			const $this = $(this);
			parks.push({
				lat: parseFloat($this.data('lat')),
				lng: parseFloat($this.data('lng')),
				link: $this.data('link'),
				name: $this.data('park-name'),
				city: $this.data('city')
			});
		});

		return parks;
	},

	renderMap: function () {
		const latitude = this.parks[0].lat || 45.2544856;
		const longitude = this.parks[0].lng || 19.834392;
		let zoomLvl = 8;

		if($(window).width() < 768) {
			zoomLvl = 7;
		}

		// rendering the google map with already set position and zoom level
		const mapOptions = {
			center: new google.maps.LatLng(latitude, longitude),
			zoom: zoomLvl,
			draggable: true,
			mapTypeId: google.maps.MapTypeId.ROADMAP,
			mapTypeControlOptions: {
				style: google.maps.ZoomControlStyle.SMALL,
				position: google.maps.ControlPosition.TOP_RIGHT
			},
			styles: this.mapStyles
		};

		this.map = new google.maps.Map($('.sw-map-container')[0], mapOptions);
	},

	renderParks: function () {
		const _this = this;

		for (let i = 0; i < _this.parks.length; i++) {
			const park = _this.parks[i];
			const marker = new google.maps.Marker({
				position: new google.maps.LatLng(park.lat, park.lng),
				draggable: false,
				animation: google.maps.Animation.DROP,
				map: _this.map,
				city: park.city
			});

			marker.addListener('click', function () {
				const link = park.link ? `<p><a href="${park.link}" target="_blank">Street View</a></p>` : "";
				_this.infoWindow.setContent(`<div><h3>${park.name}</h3>${link}</div>`);
				_this.infoWindow.open(_this.map, marker);
				_this.map.setCenter(marker.position);
				_this.map.setZoom(_this.mapZoomOnClick);
			});

			_this.markers.push(marker);
		}
	},

	bindFilter: function () {
		const _this = this;
		
		$(_this.filterSelector).off('click').on('click', _this.filterButtonSelector, function () {
			const city = $(this).data('city');
			let center = '';

			for (let i = 0; i < _this.markers.length; i++) {
				const m = _this.markers[i];
				const isMatch = m.city === city;
				m.setVisible(isMatch);
				if (isMatch && center === '') {
					center = m.position;
				}
			}

			if (center !== '') {
				_this.map.setCenter(center);
				_this.map.setZoom(_this.mapZoomOnClick);
			}
		});
	}
};
