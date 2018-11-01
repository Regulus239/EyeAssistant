#!/usr/bin/env python
# Module inspired by example from https://docs.python.org/2/library/email-examples.html
"""Unpack a MIME message into a directory of files."""

import email
import mimetypes

from optparse import OptionParser

def decode_MIME_messages(data):
    print(len(data))
    print(data[0])
    """for part in data[0].walk():
    # multipart/* are just containers
        if part.get_content_maintype() == 'multipart':
            continue
        part.get_payload(decode=True)
    print(part)
    return part
    """