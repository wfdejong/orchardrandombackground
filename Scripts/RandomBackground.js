$(document).ready(function(){
	
	var images = [];
	images.push('001.JPG');
	images.push('002.JPG');
	images.push('003.JPG');
	images.push('004.JPG');
	images.push('005.JPG');
	images.push('006.JPG');
	images.push('007.JPG');
	images.push('008.JPG');
	images.push('009.JPG');
	images.push('010.JPG');
	images.push('011.JPG');
	images.push('012.JPG');
	images.push('013.JPG');
	images.push('014.JPG');
	images.push('015.JPG');
	images.push('016.JPG');
	images.push('017.JPG');
	images.push('018.JPG');
	images.push('019.JPG');

	bgImageTotal = images.length;
 
	randomNumber = Math.round(Math.random()*(bgImageTotal-1));
	
	imgPath = ('/Themes/WillemDeJong/Content/Backgrounds/' + images[randomNumber]);

	$('html').css('background-image', ('url("' + imgPath + '")'));
 
	});