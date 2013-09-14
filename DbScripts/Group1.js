printjson(

db.Log.Domain.LogRecord.group({	key: {"$Logger":1, "$Level":1}, cond:{}, reduce:  function(curr, result) {result.total++;}, initial: {total : 0}})
);