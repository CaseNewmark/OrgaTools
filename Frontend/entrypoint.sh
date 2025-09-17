set -e
API_BASEURL=${API_BASEURL:-http://localhost:8080}
echo "Injecting API_BASEURL=${API_BASEURL} into config.json"
# Replace value in config.json
sed -i "s|\"apiBaseUrl\": \".*\"|\"apiBaseUrl\": \"${API_BASEURL}\"|" /usr/share/nginx/html/config.json
# Start nginx
exec nginx -g "daemon off;"