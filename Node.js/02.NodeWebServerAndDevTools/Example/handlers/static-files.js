let fs = require('fs')
let url = require('url')

module.exports =(req,res) => {
req.pathName = req.pathName || url.parse(req.url).pathname

     fs.readFile('.' + req.pathName, (err,data) => {
       if(err){
         res.writeHead(404)
         res.write('404 Not Found')
         res.end()
         return true
       }

let contentType = 'text/plain'
       if(req.pathName.endsWith('.css')){
            contentType = 'text/css'
       }
       else if(req.pathName.endsWith('.js')){
         contentType = 'application/javascript'
       }

       res.writeHead(200, {
         'Content-Type': contentType
       })
       res.write(data)
       res.end()
     })
  }