mkdir small;

ls -1 | grep 'png$' | while read fl; do 
    echo $fl; 
    magick.exe convert "$fl"  -resize 1024x1024 "small/$fl";
done;


