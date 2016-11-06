cd /Users/oskar/Egna\ Dokument/Programmering/Emelie/bin/Debug

mono Emelie.exe /Users/oskar/Egna%20Dokument/Programmering/Emelie/Emelie%20files/sailors.emelie /Users/oskar/Egna%20Dokument/Programmering/Emelie/Evert%20files/stories.evert 100

STARTING_POINT="start"
DICTIONARY_PATH="/Users/oskar/Egna%20Dokument/Programmering/Emelie/Evert%20files/"
OUTPUT_FILE="/Users/oskar/Egna%20Dokument/Programmering/Emelie/evert_output.html"

cd /Users/oskar/Egna\ Dokument/Programmering/Twitterbotar/EvertTextEngine/EvertTextEngine/obj/x86/Debug 

mono EvertTextEngine.exe $STARTING_POINT $DICTIONARY_PATH $OUTPUT_FILE 100 print_results

echo "\n";