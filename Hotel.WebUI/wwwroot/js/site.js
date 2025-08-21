/**
 * Avatar Generator - Görsel yükleme hatalarında fallback avatar üretir
 */
class AvatarGenerator {
    static colors = ['#4A90E2', '#50C878', '#E2A94A', '#E24A4A', '#8A2BE2', '#FF6B6B', '#4ECDC4', '#45B7D1'];

    /**
     * İsimden avatar SVG'si üretir
     * @param {string} name - Kişi adı
     * @param {number} size - Avatar boyutu
     * @returns {string} Base64 encoded SVG
     */
    static generateSVGAvatar(name, size = 40) {
        const initials = this.getInitials(name);
        const color = this.getColorFromName(name);

        const svg = `
            <svg width="${size}" height="${size}" viewBox="0 0 ${size} ${size}" xmlns="http://www.w3.org/2000/svg">
                <rect width="${size}" height="${size}" fill="${color}" rx="${size * 0.2}"/>
                <text x="50%" y="50%" dominant-baseline="middle" text-anchor="middle" 
                      fill="white" font-size="${size * 0.4}px" font-family="Arial, sans-serif" font-weight="600">
                    ${initials}
                </text>
            </svg>
        `;

        return `data:image/svg+xml;base64,${btoa(svg)}`;
    }

    /**
     * İsimden baş harfleri alır
     * @param {string} name 
     * @returns {string} Baş harfler (max 2)
     */
    static getInitials(name) {
        if (!name) return '?';

        const words = name.trim().split(' ').filter(word => word.length > 0);
        if (words.length === 1) {
            return words[0].charAt(0).toUpperCase();
        }
        return words.slice(0, 2).map(word => word.charAt(0).toUpperCase()).join('');
    }

    /**
     * İsimden renk üretir
     * @param {string} name 
     * @returns {string} Hex color
     */
    static getColorFromName(name) {
        let hash = 0;
        for (let i = 0; i < name.length; i++) {
            const char = name.charCodeAt(i);
            hash = ((hash << 5) - hash) + char;
            hash = hash & hash; // Convert to 32-bit integer
        }
        return this.colors[Math.abs(hash) % this.colors.length];
    }

    /**
     * Tüm resimlere fallback handler ekler
     */
    static initializeImageFallbacks() {
        document.addEventListener('DOMContentLoaded', function () {
            // Mevcut resimleri işle
            document.querySelectorAll('img[alt]').forEach(img => {
                AvatarGenerator.addFallbackHandler(img);
            });

            // Dinamik olarak eklenen resimleri gözlemle
            const observer = new MutationObserver(function (mutations) {
                mutations.forEach(function (mutation) {
                    mutation.addedNodes.forEach(function (node) {
                        if (node.nodeType === 1) { // Element node
                            const images = node.querySelectorAll ? node.querySelectorAll('img[alt]') : [];
                            images.forEach(img => AvatarGenerator.addFallbackHandler(img));

                            if (node.tagName === 'IMG' && node.hasAttribute('alt')) {
                                AvatarGenerator.addFallbackHandler(node);
                            }
                        }
                    });
                });
            });

            observer.observe(document.body, {
                childList: true,
                subtree: true
            });
        });
    }

    /**
     * Tek bir resme fallback handler ekler
     * @param {HTMLImageElement} img 
     */
    static addFallbackHandler(img) {
        if (img.dataset.fallbackAdded) return;

        img.onerror = function () {
            if (this.dataset.fallbackAttempted) return;

            const name = this.getAttribute('alt') || 'User';
            const rect = this.getBoundingClientRect();
            const size = Math.max(rect.width, rect.height) || 40;

            this.src = AvatarGenerator.generateSVGAvatar(name, size);
            this.dataset.fallbackAttempted = 'true';
            this.onerror = null; // Sonsuz döngüyü önle
        };

        img.dataset.fallbackAdded = 'true';
    }
}

// Otomatik başlatma
AvatarGenerator.initializeImageFallbacks();

// Global erişim için
window.AvatarGenerator = AvatarGenerator;