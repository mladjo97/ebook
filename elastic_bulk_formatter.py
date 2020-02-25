# @desc: script that formats json array data to elastic bulk data
# @author: mladen milosevic
# @date: 25.02.2020.

import json
import time

inputFile = 'ebooks.json'
outputFile = 'ebooks-bulk.json'

start = time.process_time()
with open(inputFile, 'r', encoding = "utf8") as moviesFile:
  movies = json.load(moviesFile)
  with open(outputFile, 'w+') as bulkFile:
    for i in range(len(movies)):
      index = f'{{"index": {{ "_id":"{i+1}" }} }}\n'
      bulkFile.write(index)
      bulkFile.write(f'{json.dumps(movies[i])}\n')

print(time.process_time() - start)