
# A very simple Flask Hello World app for you to get started with...

from flask import Flask, request
from werkzeug.contrib.cache import SimpleCache
cache = SimpleCache()
app = Flask(__name__)

@app.route('/')
def hello_world():
    return 'Hello from Flask!'

@app.route('/receive')
def receive():
    myparam = request.args.get('myparam')
    print(str(myparam))
    cache.set('motion-sense', str(myparam), timeout=10 * 60)
    return "Message received!" + str(myparam)

@app.route('/api', methods=['GET'])
def send():
    if cache.get("motion-sense"):
        return cache.get("motion-sense")
    else:
        return "0"