%This requires the IP webcam app on your phone. Download it and 
%click start server on the bottom. There will be an IPv4 webadress at the
%bottom of the screen, replace the YOURIP part with that address.
url = 'http://YOURIP/shot.jpg';
ss  = imread(url);
fh = image(ss);
while(1)
    A  = imread(url);
    B = im2bw(A, graythresh(A));
    B = ~B;
    B(100:540, 80:400);

    [row col] = find(B);

    left = min(row);
    right = max(row);
    top = min(col);
    bottom = max(col);

    subImage = B(left:right, top:bottom);
    imshow(subImage);
    boxSize = (right -left) * (bottom - top);
    amountContained = sum(sum(subImage));
    ratio = amountContained / boxSize
    %pause;
    
    if(ratio > 1)
        disp('Not sure');
    elseif(ratio < .85 & ratio > .7)
        disp('Circle');
    elseif(ratio > .85)
        disp('Square');
    else
        disp('Not sure');
    end
%     set(fh,'CData',ss);
%     drawnow;
end

% clear;
% clc;
% A = imread('rect.png');
% B = im2bw(A, graythresh(A));
% B = ~B;
% 
% [row col] = find(B);
% 
% left = min(row);
% right = max(row);
% top = min(col);
% bottom = max(col);
% 
% subImage = B(left:right, top:bottom);
% imshow(subImage);
% amountContained = sum(sum(subImage));





