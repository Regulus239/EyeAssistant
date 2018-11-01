from fetchEmailData import fetchEmailData
from organizeEmailData import organizeEmailData
from decode_MIME_messages import decode_MIME_messages
import email

emailDataList = fetchEmailData()
organizedDataList = organizeEmailData(emailDataList)
