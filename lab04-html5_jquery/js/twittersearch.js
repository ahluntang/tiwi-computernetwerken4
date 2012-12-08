/*
 * If DOM ready: start engines
 */
$(document).ready(
  function(){
      makeHistoryItems();
      searchTweets();
      $('body').on("dblclick",".tweet",
        function(){
          $(this).hide("slow");
        }
      );
  }
);

function makeHistoryItems(){
    $('.history_item').remove(); //remove previous history objects
    var arrHistory = localStorage.twitterhistory;
    if(arrHistory !== undefined){
      arrHistory = arrHistory.split(";");
      $.each(uniqueArray(arrHistory), function(index, value) {
        $('<option>').attr('class','history_item')
                     .append(value)
                     .appendTo('#history');
      });
    }
}

function searchTweets() {
    // Declare variables to hold twitter API url and user name
    var twitter_api_url = 'http://search.twitter.com/search.json';
    var searchstring    = $("#query").val();
    if(searchstring.length <=1){
      searchstring = 'ahtanu'; // because this is an awesome twitter user.
    }
    var arrHistory = localStorage.twitterhistory;
    if(arrHistory !== undefined){
        arrHistory = arrHistory.split(";");
      } else {
        arrHistory = new Array();
    }
    arrHistory.push(searchstring);
    arrHistory = uniqueArray(arrHistory);
    localStorage.twitterhistory = arrHistory.join(";");
    makeHistoryItems();

    // Enable caching
    $.ajaxSetup({ cache: true });

    // Send JSON request
    // The returned JSON object will have a property called "results" where we find
    // a list of the tweets matching our request query
    $.getJSON(
          twitter_api_url + '?callback=?&rpp=30&q=' + encodeURIComponent(searchstring) + "&include_entities=1",
          function(data) {

            // delete tweets
            $('.tweet').remove();
            $.each(data.results, function(i, tweet) {
              // Uncomment line below to show tweet data in Fire Bug console
              // Very helpful to find out what is available in the tweet objects
              //console.log(tweet);

              // Before we continue we check that we got data
              if(tweet.text !== undefined) {
                // Calculate how many hours ago was the tweet posted
                var date_tweet = new Date(tweet.created_at);
                var date_now   = new Date();
                var date_diff  = date_now - date_tweet;
                var hours      = Math.round(date_diff/(1000*60*60));

                // Build the html string for the current tweet
                $('<tr>').addClass('tweet')
                         .append($('<td>').addClass('tweet_hours').append(hours).append(' hours ago'))
                         .append($('<td>').append($('<img>').attr('src',tweet.profile_image_url)))
                         .append($('<td>').append(tweet.from_user_name))
                         .append($('<td>').append(parseMentions(tweet.text,tweet.entities)))
                         .appendTo('#tweet_container'); // add to container
              }
            });
          }
        );
}

function parseTweet(text,entities){
  var html = parseHashTags(text,entities);
  html = parseURLs(html,entities);
  html = parseMentions(html,entities);
  return html;
}

function parseURLs(text, entities)
{
  var urls = entities.urls;
  var html = "";
  var lasti = 0;
  for (var i = 0; i < urls.length; i++)
  {
    var start = urls[i].indices[0];
    var stop = urls[i].indices[1];
  
    var t = text.substring(lasti, start);
    var tag = text.substring(start, stop);
    
    html += t;
    html += "<a href='" + urls[i].expanded_url + "' target=\"_blank\">" + urls[i].expanded_url + "</a> ";
    
    lasti = stop;
  }
  html += text.substring(lasti);
  //console.log(text);
  //console.log(html);
  return html;
}

function parseMentions(text, entities)
{
  var mentions = entities.user_mentions;
  var html = "";
  var lasti = 0;
  for (var i = 0; i < mentions.length; i++)
  {
    var start = mentions[i].indices[0];
    var stop = mentions[i].indices[1];
  
    var t = text.substring(lasti, start);
    var tag = text.substring(start, stop);
    
    html += t;
    html += "<a href='javascript:handleClickHashTag(\"@" + mentions[i].screen_name + "\")'>@" + mentions[i].screen_name + "</a> ";
    
    lasti = stop;
  }
  html += text.substring(lasti);
  //console.log(text);
  //console.log(html);
  return html;
}

function parseHashTags(text, entities)
{
  var hashtags = entities.hashtags;
  //console.log(hashtags.length + " hashtags");
  var html = "";
  var lasti = 0;
  for (var i = 0; i < hashtags.length; i++)
  {
    var start = hashtags[i].indices[0];
    var stop = hashtags[i].indices[1];
  
    var t = text.substring(lasti, start);
    var tag = text.substring(start, stop);
    
    html += t;
    html += "<a href='javascript:handleClickHashTag(\"" + tag + "\")'>" + tag + "</a> ";
    
    lasti = stop;
  }
  html += text.substring(lasti);
  //console.log(text);
  //console.log(html);
  return html;
}

/*
 * Utility functions
 */
function uniqueArray(dupeArray){ // remove duplicate items from array
  var uniqueArray = dupeArray.filter(
                                       function(elem, pos) {
                                        return dupeArray.indexOf(elem) == pos;
                                       }
                                    );
  return uniqueArray;
};

/*
 * BIND EVENTHANDLERS TO EVENTS
 */
$('#search').click(searchTweets);

$('#query').keypress(function(e) {
  if (e.which == 13) { // catch Enter/Return key
    searchTweets(); // invoke search
    e.preventDefault(); // prevent default eventhandler(s) if Enter/Return key has been used
    return false;
  }
});

$("#history").change(
    function() {
      var search_item = $(this).val();
      $("#query").val(search_item);
      searchTweets();
    }
);

$('#clear').click(function(){
    $('.history_item').remove();
    localStorage.clear();
});

function handleClickHashTag(hashtag)
{
  $("#query").val(hashtag);
  searchTweets();
}