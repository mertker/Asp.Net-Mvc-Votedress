

//Anasayfa chart 1

//Quick fix for resizing some things for mobile-ish viewers
var mobileScreen = ($(window).innerWidth() < 500 ? true : false);

//Scatterplot
var margin = { left: 60, top: 20, right: 20, bottom: 60 },
    width = Math.min($("#chart").width(), 840) - margin.left - margin.right,
    height = width * 2 / 3;

var svg = d3.select("#chart").append("svg")
    .attr("width", (width + margin.left + margin.right))
    .attr("height", (height + margin.top + margin.bottom));

var wrapper = svg.append("g").attr("class", "chordWrapper")
    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

//////////////////////////////////////////////////////
///////////// Initialize Axes & Scales ///////////////
//////////////////////////////////////////////////////

var opacityCircles = 0.7,
    maxDistanceFromPoint = 50;

//Set the color for each region
var color = d3.scale.ordinal()
    .range(["#EFB605", "#E58903", "#E01A25", "#C20049", "#991C71", "#66489F", "#2074A0"])
    .domain(["Akdeniz", "Ege", "Marmara", "Karadeniz", "İç Anadolu", "Doğu Anadolu", "Güneydoğu Anadolu"]);

//Set the new x axis range
var xScale = d3.scale.log()
    .range([0, width])
   /* .domain([100, 2e5]);*/ //I prefer this exact scale over the true range and then using "nice"
.domain(d3.extent(countries, function(d) { return d.GDP_perCapita; }))
.nice();
//Set new x-axis
var xAxis = d3.svg.axis()
    .orient("bottom")
    .ticks(2)
    .tickFormat(function (d) {
        return xScale.tickFormat((mobileScreen ? 4 : 8), function (d) {
            var prefix = d3.formatPrefix(d);
            return prefix.scale(d) - 5 + "-" + prefix.scale(d);
        })(d);
    })
    .scale(xScale);
//Append the x-axis
wrapper.append("g")
    .attr("class", "x axis")
    .attr("transform", "translate(" + 0 + "," + height + ")")
    .call(xAxis);

//Set the new y axis range
var yScale = d3.scale.linear()
    .range([height, 0])
    .domain(d3.extent(countries, function (d) { return d.lifeExpectancy; }))
    .nice();
var yAxis = d3.svg.axis()
    .orient("left")
    .ticks(6)  //Set rough # of ticks
    .scale(yScale);
//Append the y-axis
wrapper.append("g")
    .attr("class", "y axis")
    .attr("transform", "translate(" + 0 + "," + 0 + ")")
    .call(yAxis);

//Scale for the bubble size
var rScale = d3.scale.sqrt()
    .range([mobileScreen ? 1 : 2, mobileScreen ? 10 : 16])
    .domain(d3.extent(countries, function (d) { return d.GDP; }));

//////////////////////////////////////////////////////
///////////////// Initialize Labels //////////////////
//////////////////////////////////////////////////////

//Set up X axis label
wrapper.append("g")
    .append("text")
    .attr("class", "x title")
    .attr("text-anchor", "end")
    .style("font-size", (mobileScreen ? 8 : 12) + "px")
    .attr("transform", "translate(" + width + "," + (height - 10) + ")")
    .text("Yaş");

//Set up y axis label
wrapper.append("g")
    .append("text")
    .attr("class", "y title")
    .attr("text-anchor", "end")
    .style("font-size", (mobileScreen ? 8 : 12) + "px")
    .attr("transform", "translate(18, 0) rotate(-90)")
    .text("Toplam Gelir");

////////////////////////////////////////////////////////////// 
//////////////////// Set-up voronoi ////////////////////////// 
////////////////////////////////////////////////////////////// 

//Initiate the voronoi function
//Use the same variables of the data in the .x and .y as used in the cx and cy of the circle call
//The clip extent will make the boundaries end nicely along the chart area instead of splitting up the entire SVG
//(if you do not do this it would mean that you already see a tooltip when your mouse is still in the axis area, which is confusing)
var voronoi = d3.geom.voronoi()
    .x(function (d) { return xScale(d.GDP_perCapita); })
    .y(function (d) { return yScale(d.lifeExpectancy); })
    .clipExtent([[0, 0], [width, height]]);

var voronoiCells = voronoi(countries);

////////////////////////////////////////////////////////////	
///////////// Circles to capture close mouse event /////////
////////////////////////////////////////////////////////////	

//Create wrapper for the voronoi clip paths
var clipWrapper = wrapper.append("defs")
    .attr("class", "clipWrapper");

clipWrapper.selectAll(".clip")
    .data(voronoiCells)
    .enter().append("clipPath")
    .attr("class", "clip")
    .attr("id", function (d) { return "clip-" + d.point.CountryCode; })
    .append("path")
    .attr("class", "clip-path-circle")
    .attr("d", function (d) { return "M" + d.join(",") + "Z"; });

//Initiate a group element for the circles	
var circleClipGroup = wrapper.append("g")
    .attr("class", "circleClipWrapper");

//Place the larger circles to eventually capture the mouse
var circlesOuter = circleClipGroup.selectAll(".circle-wrapper")
    .data(countries.sort(function (a, b) { return b.GDP > a.GDP; }))
    .enter().append("circle")
    .attr("class", function (d, i) { return "circle-wrapper " + d.CountryCode; })
    .attr("clip-path", function (d) { return "url(#clip-" + d.CountryCode + ")"; })
    .style("clip-path", function (d) { return "url(#clip-" + d.CountryCode + ")"; })
    .attr("cx", function (d) { return xScale(d.GDP_perCapita); })
    .attr("cy", function (d) { return yScale(d.lifeExpectancy); })
    .attr("r", maxDistanceFromPoint)
    .on("mouseover", showTooltip)
    .on("mouseout", removeTooltip);;

////////////////////////////////////////////////////////////	
/////////////////// Scatterplot Circles ////////////////////
////////////////////////////////////////////////////////////	

//Initiate a group element for the circles	
var circleGroup = wrapper.append("g")
    .attr("class", "circleWrapper");

//Place the country circles
circleGroup.selectAll("countries")
    .data(countries.sort(function (a, b) { return b.GDP > a.GDP; })) //Sort so the biggest circles are below
    .enter().append("circle")
    .attr("class", function (d, i) { return "countries " + d.CountryCode; })
    .attr("cx", function (d) { return xScale(d.GDP_perCapita); })
    .attr("cy", function (d) { return yScale(d.lifeExpectancy); })
    .attr("r", function (d) { return rScale(d.GDP); })
    .style("opacity", opacityCircles)
    .style("fill", function (d) { return color(d.Region); });

///////////////////////////////////////////////////////////////////////////
///////////////////////// Create the Legend////////////////////////////////
///////////////////////////////////////////////////////////////////////////

if (!mobileScreen) {
    //Legend			
    var legendMargin = { left: 5, top: 10, right: 5, bottom: 10 },
        legendWidth = 145,
        legendHeight = 270;

    var svgLegend = d3.select("#legend").append("svg")
        .attr("width", (legendWidth + legendMargin.left + legendMargin.right))
        .attr("height", (legendHeight + legendMargin.top + legendMargin.bottom));

    var legendWrapper = svgLegend.append("g").attr("class", "legendWrapper")
        .attr("transform", "translate(" + legendMargin.left + "," + legendMargin.top + ")");

    var rectSize = 15, //dimensions of the colored square
        rowHeight = 20, //height of a row in the legend
        maxWidth = 144; //widht of each row

    //Create container per rect/text pair  
    var legend = legendWrapper.selectAll('.legendSquare')
        .data(color.range())
        .enter().append('g')
        .attr('class', 'legendSquare')
        .attr("transform", function (d, i) { return "translate(" + 0 + "," + (i * rowHeight) + ")"; })
        .style("cursor", "pointer")
        .on("mouseover", selectLegend(0.02))
        .on("mouseout", selectLegend(opacityCircles));

    //Non visible white rectangle behind square and text for better hover
    legend.append('rect')
        .attr('width', maxWidth)
        .attr('height', rowHeight)
        .style('fill', "white");
    //Append small squares to Legend
    legend.append('rect')
        .attr('width', rectSize)
        .attr('height', rectSize)
        .style('fill', function (d) { return d; });
    //Append text to Legend
    legend.append('text')
        .attr('transform', 'translate(' + 22 + ',' + (rectSize / 2) + ')')
        .attr("class", "legendText")
        .style("font-size", "10px")
        .attr("dy", ".35em")
        .text(function (d, i) {

            if (color.domain()[i] == "Marmara") {
                return color.domain()[i] + " (" + marmaraToplamGelir+" ₺)";
            }
            else if (color.domain()[i] == "Akdeniz") {
                return color.domain()[i] + " (" + akdenizToplamGelir + " ₺)";
            }
            else if (color.domain()[i] == "Ege") {
                return color.domain()[i] + " (" + egeToplamGelir + " ₺)";
            }
            else if (color.domain()[i] == "Karadeniz") {
                return color.domain()[i] + " (" + karadenizToplamGelir + " ₺)";
            }
            else if (color.domain()[i] == "İç Anadolu") {
                return color.domain()[i] + " (" + icAnadoluToplamGelir + " ₺)";
            }
            else if (color.domain()[i] == "Doğu Anadolu") {
                return color.domain()[i] + " (" + doguAnadoluToplamGelir + " ₺)";
            }
            else if (color.domain()[i] == "Güneydoğu Anadolu") {
                return color.domain()[i].substring(0, color.domain()[i].length-3) + " (" + guneydoguAnadoluToplamGelir + " ₺)";
            }

            
        });

    //Create g element for bubble size legend
    var bubbleSizeLegend = legendWrapper.append("g")
        .attr("transform", "translate(" + (legendWidth / 2 - 30) + "," + (color.domain().length * rowHeight + 20) + ")");
    //Draw the bubble size legend
    bubbleLegend(bubbleSizeLegend, rScale, legendSizes = [50, 100, 150], legendName = "Kişi Sayısı");
}//if !mobileScreen
else {
    d3.select("#legend").style("display", "none");
}

//////////////////////////////////////////////////////
/////////////////// Bubble Legend ////////////////////
//////////////////////////////////////////////////////

function bubbleLegend(wrapperVar, scale, sizes, titleName) {

    var legendSize1 = sizes[0],
        legendSize2 = sizes[1],
        legendSize3 = sizes[2],
        legendCenter = 0,
        legendBottom = 50,
        legendLineLength = 25,
        textPadding = 5,
        numFormat = d3.format(",");

    wrapperVar.append("text")
        .attr("class", "legendTitle")
        .attr("transform", "translate(" + legendCenter + "," + 0 + ")")
        .attr("x", 0 + "px")
        .attr("y", 0 + "px")
        .attr("dy", "1em")
        .text(titleName);

    wrapperVar.append("circle")
        .attr('r', scale(legendSize1))
        .attr('class', "legendCircle")
        .attr('cx', legendCenter)
        .attr('cy', (legendBottom - scale(legendSize1)));
    wrapperVar.append("circle")
        .attr('r', scale(legendSize2))
        .attr('class', "legendCircle")
        .attr('cx', legendCenter)
        .attr('cy', (legendBottom - scale(legendSize2)));
    wrapperVar.append("circle")
        .attr('r', scale(legendSize3))
        .attr('class', "legendCircle")
        .attr('cx', legendCenter)
        .attr('cy', (legendBottom - scale(legendSize3)));

    wrapperVar.append("line")
        .attr('class', "legendLine")
        .attr('x1', legendCenter)
        .attr('y1', (legendBottom - 2 * scale(legendSize1)))
        .attr('x2', (legendCenter + legendLineLength))
        .attr('y2', (legendBottom - 2 * scale(legendSize1)));
    wrapperVar.append("line")
        .attr('class', "legendLine")
        .attr('x1', legendCenter)
        .attr('y1', (legendBottom - 2 * scale(legendSize2)))
        .attr('x2', (legendCenter + legendLineLength))
        .attr('y2', (legendBottom - 2 * scale(legendSize2)));
    wrapperVar.append("line")
        .attr('class', "legendLine")
        .attr('x1', legendCenter)
        .attr('y1', (legendBottom - 2 * scale(legendSize3)))
        .attr('x2', (legendCenter + legendLineLength))
        .attr('y2', (legendBottom - 2 * scale(legendSize3)));

    wrapperVar.append("text")
        .attr('class', "legendText")
        .attr('x', (legendCenter + legendLineLength + textPadding))
        .attr('y', (legendBottom - 2 * scale(legendSize1)))
        .attr('dy', '0.25em')
        .text("" + numFormat(Math.round(legendSize1 / 1)));
    wrapperVar.append("text")
        .attr('class', "legendText")
        .attr('x', (legendCenter + legendLineLength + textPadding))
        .attr('y', (legendBottom - 2 * scale(legendSize2)))
        .attr('dy', '0.25em')
        .text("" + numFormat(Math.round(legendSize2 / 1)) );
    wrapperVar.append("text")
        .attr('class', "legendText")
        .attr('x', (legendCenter + legendLineLength + textPadding))
        .attr('y', (legendBottom - 2 * scale(legendSize3)))
        .attr('dy', '0.25em')
        .text("" + numFormat(Math.round(legendSize3 / 1)));

}//bubbleLegend

///////////////////////////////////////////////////////////////////////////
//////////////////// Hover function for the legend ////////////////////////
///////////////////////////////////////////////////////////////////////////

//Decrease opacity of non selected circles when hovering in the legend	
function selectLegend(opacity) {
    return function (d, i) {
        var chosen = color.domain()[i];

        wrapper.selectAll(".countries")
            .filter(function (d) { return d.Region != chosen; })
            .transition()
            .style("opacity", opacity);
    };
}//function selectLegend

///////////////////////////////////////////////////////////////////////////
/////////////////// Hover functions of the circles ////////////////////////
///////////////////////////////////////////////////////////////////////////

//Hide the tooltip when the mouse moves away
function removeTooltip(d, i) {

    //Save the chosen circle (so not the voronoi)
    var element = d3.selectAll(".countries." + d.CountryCode);

    //Fade out the bubble again
    element.style("opacity", opacityCircles);

    //Hide tooltip
    $('.popover').each(function () {
        $(this).remove();
    });

    //Fade out guide lines, then remove them
    d3.selectAll(".guide")
        .transition().duration(200)
        .style("opacity", 0)
        .remove();

}//function removeTooltip

//Show the tooltip on the hovered over slice
function showTooltip(d, i) {

    //Save the chosen circle (so not the voronoi)
    var element = d3.selectAll(".countries." + d.CountryCode);

    //Define and show the tooltip
    $(element).popover({
        placement: 'auto top',
        container: '#chart',
        trigger: 'manual',
        html: true,
        content: function () {
            return "<span style='font-size: 11px; text-align: center;'>" + d.Country + "</span>";
        }
    });
    $(element).popover('show');

    //Make chosen circle more visible
    element.style("opacity", 1);

    //Place and show tooltip
    var x = +element.attr("cx"),
        y = +element.attr("cy"),
        color = element.style("fill");

    //Append lines to bubbles that will be used to show the precise data points

    //vertical line
    wrapper
        .append("line")
        .attr("class", "guide")
        .attr("x1", x)
        .attr("x2", x)
        .attr("y1", y)
        .attr("y2", height + 20)
        .style("stroke", color)
        .style("opacity", 0)
        .transition().duration(200)
        .style("opacity", 0.5);
    //Value on the axis
    wrapper
        .append("text")
        .attr("class", "guide")
        .attr("x", x)
        .attr("y", height + 38)
        .style("fill", color)
        .style("opacity", 0)
        .style("text-anchor", "middle")
        .text("" + d3.format(".2s")(d.GDP_perCapita))
        .transition().duration(200)
        .style("opacity", 0.5);

    //horizontal line
    wrapper
        .append("line")
        .attr("class", "guide")
        .attr("x1", x)
        .attr("x2", -20)
        .attr("y1", y)
        .attr("y2", y)
        .style("stroke", color)
        .style("opacity", 0)
        .transition().duration(200)
        .style("opacity", 0.5);
    //Value on the axis
    wrapper
        .append("text")
        .attr("class", "guide")
        .attr("x", -20)
        .attr("y", y)
        .attr("dy", "0.34em")
        .style("fill", color)
        .style("opacity", 0)
        .style("text-anchor", "end")
        .text(d3.format("")(d.lifeExpectancy))
        .transition().duration(200)
        .style("opacity", 0.5);

}//function showTooltip





//Anasayfa chart 2


function dashboard(id, fData) {
    var barColor = 'steelblue';
    function segColor(c) {
        return {
            beyaz: "papayawhip", siyah: "#000000", yesil: "#008000", kirmizi: "#ff0000", sari: "#ffff00", mavi: "#1414ef", kahverengi: "#9e2929", mor:"#860186" }[c]; }

    // compute total for each state.
    fData.forEach(function (d) { d.total = d.freq.beyaz + d.freq.siyah + d.freq.yesil + d.freq.kirmizi + d.freq.sari + d.freq.kirmizi + d.freq.sari + d.freq.mavi + d.freq.kahverengi + d.freq.mor; });

    // function to handle histogram.
    function histoGram(fD) {
        var hG = {}, hGDim = { t: 60, r: 0, b: 30, l: 0 };
        hGDim.w = 500 - hGDim.l - hGDim.r,
            hGDim.h = 300 - hGDim.t - hGDim.b;

        //create svg for histogram.
        var hGsvg = d3.select(id).append("svg")
            .attr("width", hGDim.w + hGDim.l + hGDim.r)
            .attr("height", hGDim.h + hGDim.t + hGDim.b).append("g")
            .attr("transform", "translate(" + hGDim.l + "," + hGDim.t + ")");

        // create function for x-axis mapping.
        var x = d3.scale.ordinal().rangeRoundBands([0, hGDim.w], 0.1)
            .domain(fD.map(function (d) { return d[0]; }));

        // Add x-axis to the histogram svg.
        hGsvg.append("g").attr("class", "x axis")
            .attr("transform", "translate(0," + hGDim.h + ")")
            .call(d3.svg.axis().scale(x).orient("bottom"));

        // Create function for y-axis map.
        var y = d3.scale.linear().range([hGDim.h, 0])
            .domain([0, d3.max(fD, function (d) { return d[1]; })]);

        // Create bars for histogram to contain rectangles and freq labels.
        var bars = hGsvg.selectAll(".bar").data(fD).enter()
            .append("g").attr("class", "bar");

        //create the rectangles.
        bars.append("rect")
            .attr("x", function (d) { return x(d[0]); })
            .attr("y", function (d) { return y(d[1]); })
            .attr("width", x.rangeBand())
            .attr("height", function (d) { return hGDim.h - y(d[1]); })
            .attr('fill', barColor)
            .on("mouseover", mouseover)// mouseover is defined below.
            .on("mouseout", mouseout);// mouseout is defined below.

        //Create the frequency labels above the rectangles.
        bars.append("text").text(function (d) { return d3.format(",")(d[1]) })
            .attr("x", function (d) { return x(d[0]) + x.rangeBand() / 2; })
            .attr("y", function (d) { return y(d[1]) - 5; })
            .attr("text-anchor", "middle");

        function mouseover(d) {  // utility function to be called on mouseover.
            // filter for selected state.
            var st = fData.filter(function (s) { return s.State == d[0]; })[0],
                nD = d3.keys(st.freq).map(function (s) { return { type: s, freq: st.freq[s] }; });

            // call update functions of pie-chart and legend.    
            pC.update(nD);
            leg.update(nD);
        }

        function mouseout(d) {    // utility function to be called on mouseout.
            // reset the pie-chart and legend.    
            pC.update(tF);
            leg.update(tF);
        }

        // create function to update the bars. This will be used by pie-chart.
        hG.update = function (nD, color) {
            // update the domain of the y-axis map to reflect change in frequencies.
            y.domain([0, d3.max(nD, function (d) { return d[1]; })]);

            // Attach the new data to the bars.
            var bars = hGsvg.selectAll(".bar").data(nD);

            // transition the height and color of rectangles.
            bars.select("rect").transition().duration(500)
                .attr("y", function (d) { return y(d[1]); })
                .attr("height", function (d) { return hGDim.h - y(d[1]); })
                .attr("fill", color);

            // transition the frequency labels location and change value.
            bars.select("text").transition().duration(500)
                .text(function (d) { return d3.format(",")(d[1]) })
                .attr("y", function (d) { return y(d[1]) - 5; });
        }
        return hG;
    }

    // function to handle pieChart.
    function pieChart(pD) {
        var pC = {}, pieDim = { w: 250, h: 250 };
        pieDim.r = Math.min(pieDim.w, pieDim.h) / 2;

        // create svg for pie chart.
        var piesvg = d3.select(id).append("svg")
            .attr("width", pieDim.w).attr("height", pieDim.h).append("g")
            .attr("transform", "translate(" + pieDim.w / 2 + "," + pieDim.h / 2 + ")");

        // create function to draw the arcs of the pie slices.
        var arc = d3.svg.arc().outerRadius(pieDim.r - 10).innerRadius(0);

        // create a function to compute the pie slice angles.
        var pie = d3.layout.pie().sort(null).value(function (d) { return d.freq; });

        // Draw the pie slices.
        piesvg.selectAll("path").data(pie(pD)).enter().append("path").attr("d", arc)
            .each(function (d) { this._current = d; })
            .style("fill", function (d) { return segColor(d.data.type); })
            .on("mouseover", mouseover).on("mouseout", mouseout);

        // create function to update pie-chart. This will be used by histogram.
        pC.update = function (nD) {
            piesvg.selectAll("path").data(pie(nD)).transition().duration(500)
                .attrTween("d", arcTween);
        }
        // Utility function to be called on mouseover a pie slice.
        function mouseover(d) {
            // call the update function of histogram with new data.
            hG.update(fData.map(function (v) {
                return [v.State, v.freq[d.data.type]];
            }), segColor(d.data.type));
        }
        //Utility function to be called on mouseout a pie slice.
        function mouseout(d) {
            // call the update function of histogram with all data.
            hG.update(fData.map(function (v) {
                return [v.State, v.total];
            }), barColor);
        }
        // Animating the pie-slice requiring a custom function which specifies
        // how the intermediate paths should be drawn.
        function arcTween(a) {
            var i = d3.interpolate(this._current, a);
            this._current = i(0);
            return function (t) { return arc(i(t)); };
        }
        return pC;
    }

    // function to handle legend.
    function legend(lD) {
        var leg = {};

        // create table for legend.
        var legend = d3.select(id).append("table").attr('class', 'legend');

        // create one row per segment.
        var tr = legend.append("tbody").selectAll("tr").data(lD).enter().append("tr");

        // create the first column for each segment.
        tr.append("td").append("svg").attr("width", '16').attr("height", '16').append("rect")
            .attr("width", '16').attr("height", '16')
            .attr("fill", function (d) { return segColor(d.type); });

        // create the second column for each segment.
        tr.append("td").text(function (d) { return d.type; });

        // create the third column for each segment.
        tr.append("td").attr("class", 'legendFreq')
            .text(function (d) { return d3.format(",")(d.freq); });

        // create the fourth column for each segment.
        tr.append("td").attr("class", 'legendPerc')
            .text(function (d) { return getLegend(d, lD); });

        // Utility function to be used to update the legend.
        leg.update = function (nD) {
            // update the data attached to the row elements.
            var l = legend.select("tbody").selectAll("tr").data(nD);

            // update the frequencies.
            l.select(".legendFreq").text(function (d) { return d3.format(",")(d.freq); });

            // update the percentage column.
            l.select(".legendPerc").text(function (d) { return getLegend(d, nD); });
        }

        function getLegend(d, aD) { // Utility function to compute percentage.
            return d3.format("%")(d.freq / d3.sum(aD.map(function (v) { return v.freq; })));
        }

        return leg;
    }

    // calculate total frequency by segment for all state.
    var tF = ['beyaz', 'siyah', 'yesil', 'kirmizi', 'sari', 'mavi', 'kahverengi', 'mor'].map(function (d) {
        return { type: d, freq: d3.sum(fData.map(function (t) { return t.freq[d]; })) };
    });

    // calculate total frequency by state for all segment.
    var sF = fData.map(function (d) { return [d.State, d.total]; });

    var hG = histoGram(sF), // create the histogram.
        pC = pieChart(tF), // create the pie-chart.
        leg = legend(tF);  // create the legend.
}


dashboard('#dashboard', freqData);





//Anasayfa chart 3


/*
################ FORMATS ##################
-------------------------------------------
*/


var formatAsPercentage = d3.format("%"),
    formatAsPercentage1Dec = d3.format(".1%"),
    formatAsInteger = d3.format(","),
    fsec = d3.time.format("%S s"),
    fmin = d3.time.format("%M m"),
    fhou = d3.time.format("%H h"),
    fwee = d3.time.format("%a"),
    fdat = d3.time.format("%d d"),
    fmon = d3.time.format("%b")
    ;

/*
############# PIE CHART ###################
-------------------------------------------
*/



function dsPieChart() {



    var width = 400,
        height = 400,
        outerRadius = Math.min(width, height) / 2,
        innerRadius = outerRadius * .999,
        // for animation
        innerRadiusFinal = outerRadius * .5,
        innerRadiusFinal3 = outerRadius * .45,
        color = d3.scale.category20()    //builtin range of colors
        ;

    var vis = d3.select("#pieChart")
        .append("svg:svg")              //create the SVG element inside the <body>
        .data([dataset])                   //associate our data with the document
        .attr("width", width)           //set the width and height of our visualization (these will be attributes of the <svg> tag
        .attr("height", height)
        .append("svg:g")                //make a group to hold our pie chart
        .attr("transform", "translate(" + outerRadius + "," + outerRadius + ")")    //move the center of the pie chart from 0, 0 to radius, radius
        ;

    var arc = d3.svg.arc()              //this will create <path> elements for us using arc data
        .outerRadius(outerRadius).innerRadius(innerRadius);

    // for animation
    var arcFinal = d3.svg.arc().innerRadius(innerRadiusFinal).outerRadius(outerRadius);
    var arcFinal3 = d3.svg.arc().innerRadius(innerRadiusFinal3).outerRadius(outerRadius);

    var pie = d3.layout.pie()           //this will create arc data for us given a list of values
        .value(function (d) { return d.measure; });    //we must tell it out to access the value of each element in our data array

    var arcs = vis.selectAll("g.slice")     //this selects all <g> elements with class slice (there aren't any yet)
        .data(pie)                          //associate the generated pie data (an array of arcs, each having startAngle, endAngle and value properties) 
        .enter()                            //this will create <g> elements for every "extra" data element that should be associated with a selection. The result is creating a <g> for every object in the data array
        .append("svg:g")                //create a group to hold each slice (we will have a <path> and a <text> element associated with each slice)
        .attr("class", "slice")    //allow us to style things in the slices (like text)
        .on("mouseover", mouseover)
        .on("mouseout", mouseout)
        .on("click", up)
        ;

    arcs.append("svg:path")
        .attr("fill", function (d, i) { return color(i); }) //set the color for each slice to be chosen from the color function defined above
        .attr("d", arc)     //this creates the actual SVG path using the associated data (pie) with the arc drawing function
        .append("svg:title") //mouseover title showing the figures
        .text(function (d) { return d.data.category + ": " + formatAsPercentage(d.data.measure); });

    d3.selectAll("g.slice").selectAll("path").transition()
        .duration(750)
        .delay(10)
        .attr("d", arcFinal)
        ;

    // Add a label to the larger arcs, translated to the arc centroid and rotated.
    // source: http://bl.ocks.org/1305337#index.html
    arcs.filter(function (d) { return d.endAngle - d.startAngle > .2; })
        .append("svg:text")
        .attr("dy", ".35em")
        .attr("text-anchor", "middle")
        .attr("transform", function (d) { return "translate(" + arcFinal.centroid(d) + ")rotate(" + angle(d) + ")"; })
        //.text(function(d) { return formatAsPercentage(d.value); })
        .text(function (d) { return d.data.category; })
        ;

    // Computes the label angle of an arc, converting from radians to degrees.
    function angle(d) {
        var a = (d.startAngle + d.endAngle) * 90 / Math.PI - 90;
        return a > 90 ? a - 180 : a;
    }


    // Pie chart title			
    vis.append("svg:text")
        .attr("dy", ".35em")
        .attr("text-anchor", "middle")
        .text("Revenue Share 2012")
        .attr("class", "title")
        ;



    function mouseover() {
        d3.select(this).select("path").transition()
            .duration(750)
            //.attr("stroke","red")
            //.attr("stroke-width", 1.5)
            .attr("d", arcFinal3)
            ;
    }

    function mouseout() {
        d3.select(this).select("path").transition()
            .duration(750)
            //.attr("stroke","blue")
            //.attr("stroke-width", 1.5)
            .attr("d", arcFinal)
            ;
    }

    function up(d, i) {

        /* update bar chart when user selects piece of the pie chart */
        //updateBarChart(dataset[i].category);
        updateBarChart(d.data.category, color(i));
        updateLineChart(d.data.category, color(i));

    }
}

dsPieChart();







var group = "All";

function datasetBarChosen(group) {
    var ds = [];
    for (x in datasetBarChart) {
        if (datasetBarChart[x].group == group) {
            ds.push(datasetBarChart[x]);
        }
    }
    return ds;
}


function dsBarChartBasics() {

    var margin = { top: 30, right: 5, bottom: 20, left: 50 },
        width = 500 - margin.left - margin.right,
        height = 250 - margin.top - margin.bottom,
        colorBar = d3.scale.category20(),
        barPadding = 1
        ;

    return {
        margin: margin,
        width: width,
        height: height,
        colorBar: colorBar,
        barPadding: barPadding
    }
        ;
}

function dsBarChart() {

    var firstDatasetBarChart = datasetBarChosen(group);

    var basics = dsBarChartBasics();

    var margin = basics.margin,
        width = basics.width,
        height = basics.height,
        colorBar = basics.colorBar,
        barPadding = basics.barPadding
        ;

    var xScale = d3.scale.linear()
        .domain([0, firstDatasetBarChart.length])
        .range([0, width])
        ;

    // Create linear y scale 
    // Purpose: No matter what the data is, the bar should fit into the svg area; bars should not
    // get higher than the svg height. Hence incoming data needs to be scaled to fit into the svg area.  
    var yScale = d3.scale.linear()
        // use the max funtion to derive end point of the domain (max value of the dataset)
        // do not use the min value of the dataset as min of the domain as otherwise you will not see the first bar
        .domain([0, d3.max(firstDatasetBarChart, function (d) { return d.measure; })])
        // As coordinates are always defined from the top left corner, the y position of the bar
        // is the svg height minus the data value. So you basically draw the bar starting from the top. 
        // To have the y position calculated by the range function
        .range([height, 0])
        ;

    //Create SVG element

    var svg = d3.select("#barChart")
        .append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .attr("id", "barChartPlot")
        ;

    var plot = svg
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")")
        ;

    plot.selectAll("rect")
        .data(firstDatasetBarChart)
        .enter()
        .append("rect")
        .attr("x", function (d, i) {
            return xScale(i);
        })
        .attr("width", width / firstDatasetBarChart.length - barPadding)
        .attr("y", function (d) {
            return yScale(d.measure);
        })
        .attr("height", function (d) {
            return height - yScale(d.measure);
        })
        .attr("fill", "lightgrey")
        ;


    // Add y labels to plot	

    plot.selectAll("text")
        .data(firstDatasetBarChart)
        .enter()
        .append("text")
        .text(function (d) {
            return formatAsInteger(d3.round(d.measure));
        })
        .attr("text-anchor", "middle")
        // Set x position to the left edge of each bar plus half the bar width
        .attr("x", function (d, i) {
            return (i * (width / firstDatasetBarChart.length)) + ((width / firstDatasetBarChart.length - barPadding) / 2);
        })
        .attr("y", function (d) {
            return yScale(d.measure) + 14;
        })
        .attr("class", "yAxis")
        /* moved to CSS			   
        .attr("font-family", "sans-serif")
        .attr("font-size", "11px")
        .attr("fill", "white")
        */
        ;

    // Add x labels to chart	

    var xLabels = svg
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + (margin.top + height) + ")")
        ;

    xLabels.selectAll("text.xAxis")
        .data(firstDatasetBarChart)
        .enter()
        .append("text")
        .text(function (d) { return d.category; })
        .attr("text-anchor", "middle")
        // Set x position to the left edge of each bar plus half the bar width
        .attr("x", function (d, i) {
            return (i * (width / firstDatasetBarChart.length)) + ((width / firstDatasetBarChart.length - barPadding) / 2);
        })
        .attr("y", 15)
        .attr("class", "xAxis")
        //.attr("style", "font-size: 12; font-family: Helvetica, sans-serif")
        ;

    // Title

    svg.append("text")
        .attr("x", (width + margin.left + margin.right) / 2)
        .attr("y", 15)
        .attr("class", "title")
        .attr("text-anchor", "middle")
        .text("Overall Ayının Satış Performansı 2018")
        ;
}

dsBarChart();

/* ** UPDATE CHART ** */

/* updates bar chart on request */

function updateBarChart(group, colorChosen) {

    var currentDatasetBarChart = datasetBarChosen(group);

    var basics = dsBarChartBasics();

    var margin = basics.margin,
        width = basics.width,
        height = basics.height,
        colorBar = basics.colorBar,
        barPadding = basics.barPadding
        ;

    var xScale = d3.scale.linear()
        .domain([0, currentDatasetBarChart.length])
        .range([0, width])
        ;


    var yScale = d3.scale.linear()
        .domain([0, d3.max(currentDatasetBarChart, function (d) { return d.measure; })])
        .range([height, 0])
        ;

    var svg = d3.select("#barChart svg");

    var plot = d3.select("#barChartPlot")
        .datum(currentDatasetBarChart)
        ;

    /* Note that here we only have to select the elements - no more appending! */
    plot.selectAll("rect")
        .data(currentDatasetBarChart)
        .transition()
        .duration(750)
        .attr("x", function (d, i) {
            return xScale(i);
        })
        .attr("width", width / currentDatasetBarChart.length - barPadding)
        .attr("y", function (d) {
            return yScale(d.measure);
        })
        .attr("height", function (d) {
            return height - yScale(d.measure);
        })
        .attr("fill", colorChosen)
        ;

    plot.selectAll("text.yAxis") // target the text element(s) which has a yAxis class defined
        .data(currentDatasetBarChart)
        .transition()
        .duration(750)
        .attr("text-anchor", "middle")
        .attr("x", function (d, i) {
            return (i * (width / currentDatasetBarChart.length)) + ((width / currentDatasetBarChart.length - barPadding) / 2);
        })
        .attr("y", function (d) {
            return yScale(d.measure) + 14;
        })
        .text(function (d) {
            return formatAsInteger(d3.round(d.measure));
        })
        .attr("class", "yAxis")
        ;


    svg.selectAll("text.title") // target the text element(s) which has a title class defined
        .attr("x", (width + margin.left + margin.right) / 2)
        .attr("y", 15)
        .attr("class", "title")
        .attr("text-anchor", "middle")
        .text(group + " Ayının Kategori Performansları 2018")
        ;
}




var group = "All";

function datasetLineChartChosen(group) {
    var ds = [];
    for (x in datasetLineChart) {
        if (datasetLineChart[x].group == group) {
            ds.push(datasetLineChart[x]);
        }
    }
    return ds;
}

function dsLineChartBasics() {

    var margin = { top: 20, right: 10, bottom: 0, left: 50 },
        width = 500 - margin.left - margin.right,
        height = 150 - margin.top - margin.bottom
        ;

    return {
        margin: margin,
        width: width,
        height: height
    }
        ;
}


function dsLineChart() {

    var firstDatasetLineChart = datasetLineChartChosen(group);

    var basics = dsLineChartBasics();

    var margin = basics.margin,
        width = basics.width,
        height = basics.height
        ;

    var xScale = d3.scale.linear()
        .domain([0, firstDatasetLineChart.length - 1])
        .range([0, width])
        ;

    var yScale = d3.scale.linear()
        .domain([0, d3.max(firstDatasetLineChart, function (d) { return d.measure; })])
        .range([height, 0])
        ;

    var line = d3.svg.line()
        //.x(function(d) { return xScale(d.category); })
        .x(function (d, i) { return xScale(i); })
        .y(function (d) { return yScale(d.measure); })
        ;

    var svg = d3.select("#lineChart").append("svg")
        .datum(firstDatasetLineChart)
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
    // create group and move it so that margins are respected (space for axis and title)

    var plot = svg
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")")
        .attr("id", "lineChartPlot")
        ;

    /* descriptive titles as part of plot -- start */
    var dsLength = firstDatasetLineChart.length;

    plot.append("text")
        .text(firstDatasetLineChart[dsLength - 1].measure+" ₺")
        .attr("id", "lineChartTitle2")
        .attr("x", width / 2)
        .attr("y", height / 2)
        ;
    /* descriptive titles -- end */

    plot.append("path")
        .attr("class", "line")
        .attr("d", line)
        // add color
        .attr("stroke", "lightgrey")
        ;

    plot.selectAll(".dot")
        .data(firstDatasetLineChart)
        .enter().append("circle")
        .attr("class", "dot")
        //.attr("stroke", function (d) { return d.measure==datasetMeasureMin ? "red" : (d.measure==datasetMeasureMax ? "green" : "steelblue") } )
        .attr("fill", function (d) { return d.measure == d3.min(firstDatasetLineChart, function (d) { return d.measure; }) ? "red" : (d.measure == d3.max(firstDatasetLineChart, function (d) { return d.measure; }) ? "green" : "white") })
        //.attr("stroke-width", function (d) { return d.measure==datasetMeasureMin || d.measure==datasetMeasureMax ? "3px" : "1.5px"} )
        .attr("cx", line.x())
        .attr("cy", line.y())
        .attr("r", 3.5)
        .attr("stroke", "lightgrey")
        .append("title")
        .text(function (d) { return d.category + ": " + formatAsInteger(d.measure); })
        ;

    svg.append("text")
        .text("Performans 2018")
        .attr("id", "lineChartTitle1")
        .attr("x", margin.left + ((width + margin.right) / 2))
        .attr("y", 10)
        ;

}

dsLineChart();


/* ** UPDATE CHART ** */

/* updates bar chart on request */
function updateLineChart(group, colorChosen) {

    var currentDatasetLineChart = datasetLineChartChosen(group);

    var basics = dsLineChartBasics();

    var margin = basics.margin,
        width = basics.width,
        height = basics.height
        ;

    var xScale = d3.scale.linear()
        .domain([0, currentDatasetLineChart.length - 1])
        .range([0, width])
        ;

    var yScale = d3.scale.linear()
        .domain([0, d3.max(currentDatasetLineChart, function (d) { return d.measure; })])
        .range([height, 0])
        ;

    var line = d3.svg.line()
        .x(function (d, i) { return xScale(i); })
        .y(function (d) { return yScale(d.measure); })
        ;

    var plot = d3.select("#lineChartPlot")
        .datum(currentDatasetLineChart)
        ;

    /* descriptive titles as part of plot -- start */
    var dsLength = currentDatasetLineChart.length;

    plot.select("text")
        .text(currentDatasetLineChart[dsLength - 1].measure+" ₺")
        ;
    /* descriptive titles -- end */

    plot
        .select("path")
        .transition()
        .duration(750)
        .attr("class", "line")
        .attr("d", line)
        // add color
        .attr("stroke", colorChosen)
        ;

    var path = plot
        .selectAll(".dot")
        .data(currentDatasetLineChart)
        .transition()
        .duration(750)
        .attr("class", "dot")
        .attr("fill", function (d) { return d.measure == d3.min(currentDatasetLineChart, function (d) { return d.measure; }) ? "red" : (d.measure == d3.max(currentDatasetLineChart, function (d) { return d.measure; }) ? "green" : "white") })
        .attr("cx", line.x())
        .attr("cy", line.y())
        .attr("r", 3.5)
        // add color
        .attr("stroke", colorChosen)
        ;

    path
        .selectAll("title")
        .text(function (d) { return d.category + ": " + formatAsInteger(d.measure); })
        ;

}