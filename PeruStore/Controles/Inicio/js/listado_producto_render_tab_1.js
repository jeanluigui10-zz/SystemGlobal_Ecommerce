

function Fn_Render_Lista_Producto_Tab_1() {

    //(function (element) {
    var $element = $("#so_listing_tabs_1"),
		$tab = $('.ltabs-tab', $element),
		$tab_label = $('.ltabs-tab-label', $tab),
		$tabs = $('.ltabs-tabs', $element),
		ajax_url = $tabs.parents('.ltabs-tabs-container').attr('data-ajaxurl'),
		effect = $tabs.parents('.ltabs-tabs-container').attr('data-effect'),
		delay = $tabs.parents('.ltabs-tabs-container').attr('data-delay'),
		duration = $tabs.parents('.ltabs-tabs-container').attr('data-duration'),
		type_source = $tabs.parents('.ltabs-tabs-container').attr('data-type_source'),

		$col_lg = $tabs.parents('.ltabs-tabs-container').attr('data-lg'),
		$col_md = $tabs.parents('.ltabs-tabs-container').attr('data-md'),
		$col_sm = $tabs.parents('.ltabs-tabs-container').attr('data-sm'),
		$col_xs = $tabs.parents('.ltabs-tabs-container').attr('data-xs'),
		$margin = $tabs.parents('.ltabs-tabs-container').attr('data-margin'),

		$items_content = $('.ltabs-items', $element),
		$items_inner = $('.ltabs-items-inner', $items_content),
		$items_first_active = $('.ltabs-items-selected', $element),
		$select_box = $('.ltabs-selectbox', $element),
		$tab_label_select = $('.ltabs-tab-selected', $element),
		setting = '2',
		type_show = 'slider';
		enableSelectBoxes();

		/* First Ajax Listing tabs*/
		var el = $('.tab-sel',$element).attr('data-active-content'),
			el_active = $(el,$element);
		listing_tab_ajax(el_active);

	function enableSelectBoxes() {
		$tab_wrap = $('.ltabs-tabs-wrap', $element),
			$tab_label_select.html($('.ltabs-tab', $element).filter('.tab-sel').children('.ltabs-tab-label').html());
		if ($(window).innerWidth() <= 991) {
			$tab_wrap.addClass('ltabs-selectbox');
		} else {
			$tab_wrap.removeClass('ltabs-selectbox');
		}
	}

	$('span.ltabs-tab-selected, span.ltabs-tab-arrow', $element).click(function() {
		if ($('.ltabs-tabs', $element).hasClass('ltabs-open')) {
			$('.ltabs-tabs', $element).removeClass('ltabs-open');
		} else {
			$('.ltabs-tabs', $element).addClass('ltabs-open');
		}
	});

	$(window).resize(function() {
		if ($(window).innerWidth() <= 991) {
			$('.ltabs-tabs-wrap', $element).addClass('ltabs-selectbox');
		} else {
			$('.ltabs-tabs-wrap', $element).removeClass('ltabs-selectbox');
		}
	});

	function showAnimateItems(el) {
		var $_items = $('.new-ltabs-item', el), nub = 0;
		$('.ltabs-loadmore-btn', el).fadeOut('fast');
		$_items.each(function (i) {
			nub++;
			switch(effect) {
				case 'none' : $(this).css({'opacity':'1','filter':'alpha(opacity = 100)'}); break;
				default: animatesItems($(this),nub*delay,i,el);
			}
			if (i === $_items.length - 1) {
				$('.ltabs-loadmore-btn', el).fadeIn(3000);
			}
			$(this).removeClass('new-ltabs-item');
		});
	}

	function animatesItems($this,fdelay,i,el) {
		var $_items = $('.ltabs-item', el);
		$this.stop(true, true).attr("style",
			"-webkit-animation:" + effect +" "+ duration +"ms;"
			+ "-moz-animation:" + effect +" "+ duration +"ms;"
			+ "-o-animation:" + effect +" "+ duration +"ms;"
			+ "-moz-animation-delay:" + fdelay + "ms;"
			+ "-webkit-animation-delay:" + fdelay + "ms;"
			+ "-o-animation-delay:" + fdelay + "ms;"
			+ "animation-delay:" + fdelay + "ms;").delay(fdelay).animate({
				opacity: 1,
				filter: 'alpha(opacity = 100)'
			}, {
				delay: 1000
			});
		if (i === ($_items.length - 1)) {
			$(".ltabs-items-inner").addClass("play");
		}
	}


	function updateStatus($el) {
		$('.ltabs-loadmore-btn', $el).removeClass('loading');
		var countitem = $('.ltabs-item', $el).length;
		$('.ltabs-image-loading', $el).css({display: 'none'});
		$('.ltabs-loadmore-btn', $el).parent().attr('data-rl_start', countitem);
		var rl_total = $('.ltabs-loadmore-btn', $el).parent().attr('data-rl_total');
		var rl_load = $('.ltabs-loadmore-btn', $el).parent().attr('data-rl_load');
		var rl_allready = $('.ltabs-loadmore-btn', $el).parent().attr('data-rl_allready');

		if (countitem >= rl_total) {
			$('.ltabs-loadmore-btn', $el).addClass('loaded');
			$('.ltabs-image-loading', $el).css({display: 'none'});
			$('.ltabs-loadmore-btn', $el).attr('data-label', rl_allready);
			$('.ltabs-loadmore-btn', $el).removeClass('loading');
		}
	}

	function listing_tab_ajax(category_id ) {	
		var parent_active = $(category_id),
		total_product = parent_active.data('total'),
		tab_active = $('.ltabs-items-inner', parent_active),
		nb_column0 = $col_lg,
		nb_column1 = $col_md,
		nb_column2 = $col_sm,
		nb_column3 = $col_xs;
		nb_margin = parseInt($margin);
		tab_active.owlCarousel2({
			nav: true,
			dots: false,

			loop: false,
			autoplay: false,
			lazyLoad: true,
			autoplayHoverPause: true,
			autoplayTimeout: 5000,
			autoplaySpeed: 5000,
			navRewind: true,
			navText: ['', ''],
			margin: nb_margin ,
			responsive: {
				0: {
					items: nb_column3,
					nav: total_product <= nb_column3 ? false : true
				},
				767: {
					items: nb_column2,
					nav: total_product <= nb_column2 ? false : true
				},
				991: {
					items: nb_column1,
					nav: total_product <= nb_column1 ? false : true
				},
				1199: {
					items: nb_column0,

					nav: total_product <= nb_column0 ? false : true
				},
			}
		});

		/*Quick View*/
		$('.iframe-link').magnificPopup({
			type:'iframe',
			fixedContentPos: true,
			fixedBgPos: true,
			overflowY: 'auto',
			closeBtnInside: true,
			closeOnContentClick: true,
			preloader: true,
			midClick: true,
			removalDelay: 300,
			mainClass: 'my-mfp-zoom-in',
			//gallery: {  enabled: true }
		});


		$( '.product_1846281811484147376 .thumbs-product .item-img', $(category_id) ).click(function() {
			$( '.product_1846281811484147376 .thumbs-product .item-img', $(category_id) ).removeClass('thumb-active');
			$(this).addClass('thumb-active');
			var thumb_src = $(this).attr("data-src");
			$( ".product_1846281811484147376 .product-image-container img", $(category_id)).attr("src",thumb_src);
		}); 
	}

	$tab.on('click.ltabs-tab', function () {

		var $this = $(this);
		if ($this.hasClass('tab-sel')) return false;
		if ($this.parents('.ltabs-tabs').hasClass('ltabs-open')) {
			$this.parents('.ltabs-tabs').removeClass('ltabs-open');
		}
		$tab.removeClass('tab-sel');
		$this.addClass('tab-sel');
		var items_active = $this.attr('data-active-content');
		var _items_active = $(items_active,$element);
		$items_content.removeClass('ltabs-items-selected');
		_items_active.addClass('ltabs-items-selected');
		$tab_label_select.html($tab.filter('.tab-sel').children('.ltabs-tab-label').html());
		var $loading = $('.ltabs-loading', _items_active);
		var loaded = _items_active.hasClass('ltabs-items-loaded');


		type_show =$tabs.parents('.ltabs-tabs-container').attr('data-type_show');
		if (!loaded && !_items_active.hasClass('ltabs-process')) {
			_items_active.addClass('ltabs-process');
			var category_id 		= $this.attr('data-category-id'),
			path_url 	= 'ajax/listingtab_',
			ajax_url = $tabs.parents('.ltabs-tabs-container').attr('data-ajaxurl')+path_url+category_id+ '.html';

			$loading.show();
			$.ajax({
				type: 'POST',
				url: ajax_url,
				//dataType: 'json',// when on gave connection errors
				data: {
					is_ajax_listing_tabs: 1,
					ajax_reslisting_start: 1,
					categoryid: category_id,
					setting: setting,
					lbmoduleid: 1,
				},
				success: function (data) {

					if (data !== '') {

						$('.ltabs-loading', _items_active).replaceWith(data);
						_items_active.addClass('ltabs-items-loaded').removeClass('ltabs-process');
						$loading.remove();
						if (type_show !== 'slider') {
							showAnimateItems(_items_active);
						}
						updateStatus(_items_active);
						listing_tab_ajax(_items_active);
					}
					if(typeof(_SoQuickView) !== 'undefined'){
						_SoQuickView();
					}

				},
				error: function(xhr, ajaxOptions, thrownError) {
					alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
				}

			});

		} else {
			if (type_show === 'loadmore') {
				$('.ltabs-item', $items_content).removeAttr('style').addClass('new-ltabs-item');
				showAnimateItems(_items_active);
			}else{
				var $tag_id = $element;
				var owl = $('.owl2-carousel' , _items_active);
				var $navpage = $(".wap-listing-tabs", $tag_id);
				$navpage.siblings(".owl2-controls").addClass('hidden');

				owl = owl.data('owlCarousel2');

				if (typeof owl !== 'undefined') {
					owl.onResize();
				}
			}
		}
	});
    //})('#so_listing_tabs_1');

}

