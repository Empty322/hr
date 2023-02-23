image:
	docker build -t hr -f hr/Dockerfile .
containers:
	docker compose -f docker-compose.yml create