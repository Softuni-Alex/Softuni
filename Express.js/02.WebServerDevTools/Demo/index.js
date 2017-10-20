const http = require('http')
const url = require('url')
const fs = require('fs')
const port = 1337
const faviconIco = './favicon.ico'

http.createServer((req, res) => {
    let path = url.parse(req.url).pathname

    if (path === "/") {
        fs.readFile('./index.html', (err, data) => {
            if (err) {
                console.log(err.message)
                return
            }

            res.writeHead(200, {
                'content-type': 'text/html'
            })
            res.write(data)
            res.end()
        })
    } else if (path === faviconIco) {
        fs.readFile('.' + faviconIco, (err, data) => {
            if (err) {
                console.log(err.message)
                return
            }

            res.writeHead(200, {
                'content-type': 'image/x-icon'
            })
            res.write(data)
            res.end()
        })
    }
}).listen(port)

console.log('Server is listening on port' + port)