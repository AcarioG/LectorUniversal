//var disqus_config = function (url,identifier) {
//    // Replace PAGE_URL with your page's canonical URL variable
//    this.page.url = `${url}`;

//    // Replace PAGE_IDENTIFIER with your page's unique identifier variable
//    this.page.identifier = `${identifier}`;
//};

export function DisqusFunction(disqusThreadElement) { // DON'T EDIT BELOW THIS LINE
     
            var d = document, s = d.createElement('script');
            s.src = 'https://lectoruniversal.disqus.com/embed.js';
            s.async = true;
            s.setAttribute('data-timestamp', +new Date());
            disqusThreadElement.appendChild(s);
};
