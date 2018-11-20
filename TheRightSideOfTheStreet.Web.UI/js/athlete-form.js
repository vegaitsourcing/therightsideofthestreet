'use strict';

module.exports = {

	formInit: function () {
		const $form = $("#show-yourself-form");
		if ($form.length === 0) return;

		$form.data('validator').settings.ignore = "";
	},

	handleFormSubmit: function () {
		$('#showYourselfFormButton').on('click', function (e) {
			e.preventDefault();
			const $form = $(this).closest('form');
			const $achievements = $form.find('[achievements]');
			const $inputs = $achievements.children('input:text');
			const $achievementsHidden = $achievements.next();

			$achievementsHidden.val('');

			for (let i = 0; i < $inputs.length; i++) {
				const $item = $inputs[i];
				if ($item.value.trim().length === 0) continue;
				const oldValue = $achievementsHidden.val();
				$achievementsHidden.val(oldValue + $item.value + '|');
			}

			if (!$form.valid()) return;
			$form.submit();
		});
	},

	showImagePreview: function () {

		$("#addImage").change(function () {

			const File = this.files;

			if (File && File[0]) {
				readImage(File[0]);
			}

		})

		const readImage = function (file) {

			const reader = new FileReader;
			const image = new Image;

			if (file) {
				reader.readAsDataURL(file);
			}
			reader.onload = function (_file) {

				image.src = _file.target.result;
				image.onload = function () {

					$("#targetImg").attr('src', _file.target.result);
					$('#icon').hide();
					$('#text').hide();

				}

			}

		}
	},

	showAchievementsInput: function () {

		$("[add-achievement-btn]").on('click', function () {
			const $this = $(this);
			const $parent = $this.parent();

			$parent.append("<input type='text' value=''>");
		})
	},

	hideCountryAndCityInput: function () {
		$('#Crew').on('change', function () {

			const crew = $("#Crew option:selected").text();

			$("#Country").val(crew);
			$("#Country").hide();

			$("#City").val(crew);
			$("#City").hide();

			if ($("#Crew option:selected").val() === "") {
				$("#Country").val('').show();

				$("#City").val('').show();
			}
		});
	},

	previewImages: function () {

		const originalImgSrc = $('.show-yourself-content-second img:eq(5)').attr('src');
		const $preview = $('.show-yourself-content-second')[0];
		const $imagesInput = $('#file-input')[0];
		let i = 0;

		if (!$imagesInput) return;

		if ($imagesInput.files.length > 5) {

			alert('Maximum allowed is 5 images!');
			$('#file-input').wrap('<form>').closest('form').get(0).reset();
			$('#file-input').unwrap();
			$('div.show-yourself-content-second img').attr("src", originalImgSrc);
			return;
		}

		if ($imagesInput.files) {

			$('div.show-yourself-content-second img').attr("src", originalImgSrc);

			[].forEach.call($imagesInput.files, function (file) {

				var reader = new FileReader();
				reader.addEventListener("load", function () {
					const $image = $preview.querySelectorAll('img')
					$image[i].src = this.result;
					$image[i].width = 197;
					i++;
				}, false);

				reader.readAsDataURL(file);

			});
		}
		$('#file-input')[0].addEventListener("change", this.previewImages, false);
	},

};

//Multiple images validation

jQuery.validator.unobtrusive.adapters.add('multipleimagevalid', ['imageregex'], function (options) {
	options.rules['multipleimagevalid'] = { imageregex: options.params.imageregex };
	options.messages['multipleimagevalid'] = options.message;
});

jQuery.validator.addMethod("multipleimagevalid", function (value, element, param) {

	if (value === "") return true;

	let isValid = true;

	for (var i = 0; i < element.files.length; i++) {

		const file = element.files[i];
		const regex = new RegExp(param.imageregex);

		isValid = isValid && regex.test(file.name);
	}

	return isValid;
});

jQuery.validator.unobtrusive.adapters.add('multiplefilesize', ['maxsize'], function (options) {

	var params = {
		maxsize: options.params.maxsize
	};

	// Match parameters to the method to execute
	options.rules['multiplefilesize'] = params;
	if (options.message) {
		// If there is a message, set it for the rule
		options.messages['multiplefilesize'] = options.message;
	}
});

jQuery.validator.addMethod("multiplefilesize", function (value, element, param) {

	if (value === "") return true;

	let isValid = true;

	for (var i = 0; i < element.files.length; i++) {

		var maxBytes = parseInt(param.maxsize);

		if (element.files !== undefined && element.files[i] !== undefined && element.files[i].size !== undefined) {

			var filesize = parseInt(element.files[i].size);

			isValid = isValid && filesize <= maxBytes;
		}
	}

	return isValid;

});