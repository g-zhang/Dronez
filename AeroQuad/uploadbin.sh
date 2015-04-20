now=$(date +"%m_%d_%Y")
msg="AQ Binary Updated by Script on $now"

git add "BuildAQ32/objSTM32/AeroQuad32/AeroQuadMain.bin"
git commit -m "$msg"
echo "AQBuild: Uploading AeroQuad binary to GitHub with commit message:"
echo "         $msg"
git push origin master
echo "AQBuild: Done."
