Create an XML file in Resources\values that looks like this:

<?xml version="1.0" encoding="utf-8" ?>
<resources>
  <string name="MashapeKey">Value</string>
</resources>

When I update the demo to use a different weather provider, this will
become the API key for that new provider. Until then, just create this
file so that the app will build. Mashape does not provide this service
anymore.