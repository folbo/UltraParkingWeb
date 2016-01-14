ko.bindingHandlers.googlemap = {
    init: function (element, valueAccessor) {
        var
          value = valueAccessor(),
          latLng = new google.maps.LatLng(value.latitude(), value.longitude()),
          mapOptions = {
              zoom: 12,
              center: latLng,
              mapTypeId: google.maps.MapTypeId.ROADMAP
          },
          map = new google.maps.Map(element, mapOptions),
          marker = new google.maps.Marker({
              position: latLng,
              map: map
          });

        google.maps.event.addListener(map, "click", function (event) {
            // place a marker
            marker.setPosition(event.latLng);
            value.latitude(event.latLng.lat());
            value.longitude(event.latLng.lng());
        });
    }
};