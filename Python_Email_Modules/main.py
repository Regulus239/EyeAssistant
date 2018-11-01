from fetchEmailData import fetchEmailData
from organizeEmailData import organizeEmailData
from decode_MIME_messages import decode_MIME_messages
import email

dataList = fetchEmailData()
organizedDataList = organizeEmailData(dataList)
print(msgList[0].is_multipart())
